using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseExercise
{
    public partial class Form1 : Form
    {
        private RoomWithDoor livingRoom, kitchen;
        private OutsideWithDoor backYard, frontYard;
        private Room diningRoom;
        private Outside garden;
        private Location currentLocation;

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void exits_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor door = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(door.DoorLocation);
        }

        private void MoveToANewLocation(Location newRoom)
        {
            currentLocation = newRoom;
            exits.Items.Clear();
            foreach (var exit in currentLocation.Exits)
                exits.Items.Add(exit.Name);
            exits.SelectedIndex = 0;
            description.Text = currentLocation.Description;
            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(kitchen);
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("living room", "an antique carpet", "an oak door with a brass knob");
            kitchen = new RoomWithDoor("kitchen", "stainless steel appliances", "a screen door");
            diningRoom = new Room("dining room", "a crystal chandelier");
            backYard = new OutsideWithDoor("back yard", true, "a screen door");
            frontYard = new OutsideWithDoor("front yard", false, "an oak door with a brass knob");
            garden = new Outside("garden", false);

            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { kitchen, livingRoom };
            backYard.Exits = new Location[] { frontYard, garden };
            frontYard.Exits = new Location[] { backYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };

            kitchen.DoorLocation = backYard;
            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
        }
    }
}