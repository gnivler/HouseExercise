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
            //MoveToANewLocation(kitchen);
        }


        private void check_Click(object sender, EventArgs e)
        {
            if (opponent.Check(currentLocation))
                MessageBox.Show($"You found me");
        }

        private void goHide_Click(object sender, EventArgs e)
        {
            // TODO - countdown
            for (int i = 0; i < 11; i++)
            {
                opponent.Move();
            }
            goHere.Visible = true;
            exits.Visible = true;
            goHide.Visible = false;
        }

        private Location currentLocation;
        private RoomWithHidingPlace upstairsHallway, masterBedroom, secondBedroom, bathroom;
        private RoomWithDoor livingRoom, kitchen;
        private OutsideWithDoor backYard, frontYard;
        private Room diningRoom, stairs;
        private OutsideWithHidingPlace garden, driveway;
        private Opponent opponent;

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("living room", "an antique carpet", "an oak door with a brass knob", "a closet");
            kitchen = new RoomWithDoor("kitchen", "stainless steel appliances", "a screen door", "a cabinet");
            diningRoom = new Room("dining room", "a crystal chandelier");
            backYard = new OutsideWithDoor("back yard", true, "a screen door");
            frontYard = new OutsideWithDoor("front yard", false, "an oak door with a brass knob");
            stairs = new Room("stairs", "wooden bannister");
            upstairsHallway = new RoomWithHidingPlace("upstairs hallway", "picture of a dog", "a closet");
            masterBedroom = new RoomWithHidingPlace("master bedroom", "a large bed", "a large bed");
            secondBedroom = new RoomWithHidingPlace("second bedroom", "a small bed", "a small bed");
            bathroom = new RoomWithHidingPlace("bathroom", "a sink and a toilet", "the shower");
            garden = new OutsideWithHidingPlace("garden", false, "the shed");
            driveway = new OutsideWithHidingPlace("driveway", false, "the garage");
            opponent = new Opponent(livingRoom);

            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { kitchen, livingRoom };
            backYard.Exits = new Location[] { frontYard, garden };
            frontYard.Exits = new Location[] { backYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };
            stairs.Exits = new Location[] { livingRoom, upstairsHallway };
            upstairsHallway.Exits = new Location[] { stairs, masterBedroom, secondBedroom, bathroom };
            masterBedroom.Exits = new Location[] { upstairsHallway };
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };

            kitchen.DoorLocation = backYard;
            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
        }
    }
}