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
            {
                exits.Items.Add(exit);
            }
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
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob", frontYard);
            livingRoom.Exits = new Location[] { diningRoom };

            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door", backYard);
            kitchen.Exits = new Location[] { diningRoom };

            diningRoom = new Room("Dining Room", "a crystal chandelier");
            diningRoom.Exits = new Location[] { kitchen, livingRoom };

            backYard = new OutsideWithDoor("Back Yard", true, "a screen door", kitchen);
            backYard.Exits = new Location[] { frontYard, garden };

            frontYard = new OutsideWithDoor("Front Yard", false, "an oak door with a brass knob", livingRoom);
            frontYard.Exits = new Location[] { backYard, garden };

            garden = new Outside("Garden", false);
            garden.Exits = new Location[] { frontYard, backYard };

            kitchen.DoorLocation = backYard;
            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;

        }
    }
}
