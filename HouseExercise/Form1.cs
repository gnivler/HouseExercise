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
            Moves++;
            RedrawForm();
        }

        private void RedrawForm()
        {
            IHidingPlace room = currentLocation as IHidingPlace;
            if (currentLocation is IHidingPlace && room.Checked == false)
            {
                check.Visible = true;
                check.Text = $"Check {room.HidingPlace}!";
            }
            else
            {
                check.Visible = false;
            }
            exits.Items.Clear();
            foreach (var exit in currentLocation.Exits)
            {
                exits.Items.Add(exit.Name);
            }
            exits.SelectedIndex = 0;
            description.Text = currentLocation.Description;
            if (currentLocation is IHasExteriorDoor)
            {
                goThroughTheDoor.Visible = true;
            }
            else
            {
                goThroughTheDoor.Visible = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }

        private void check_Click(object sender, EventArgs e)
        {
            if (opponent.Check(currentLocation))
            {
                MessageBox.Show($"You found me!  It took you {Moves} moves.");
                ResetGame();
            }
            else
            {
                if (currentLocation is IHidingPlace)
                {
                    IHidingPlace room = currentLocation as IHidingPlace;
                    room.Checked = true;
                }
                RedrawForm();
                MessageBox.Show($"Not in here!");
            }
        }

        private void ResetGame()
        {
            Moves = 0;
            CreateObjects();
            goHide.Visible = true;
            description.Text = "";
            goHere.Visible = false;
            check.Visible = false;
            exits.Visible = false;
        }

        private void goHide_Click(object sender, EventArgs e)
        {
            goHide.Visible = false;
            for (int i = 10; i > 0; i--)
            {
                description.Text += $"{i}...";
                opponent.Move();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }
            description.Text += $"\r\nCome and find me!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(1500);
            MoveToANewLocation(livingRoom);
            goHere.Visible = true;
            exits.Visible = true;
        }

        private int Moves;
        private Location currentLocation;
        private RoomWithHidingPlace upstairsHallway, masterBedroom, secondBedroom, bathroom;
        private RoomWithDoor livingRoom, kitchen;
        private OutsideWithDoor backYard, frontYard;
        private Room diningRoom, stairs;
        private OutsideWithHidingPlace garden, driveway;
        private Opponent opponent;

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("living room", "an antique carpet", "an oak door with a brass knob", "in the closet");
            kitchen = new RoomWithDoor("kitchen", "stainless steel appliances", "a screen door", "in the cabinet");
            diningRoom = new Room("dining room", "a crystal chandelier");
            backYard = new OutsideWithDoor("back yard", true, "a screen door");
            frontYard = new OutsideWithDoor("front yard", false, "an oak door with a brass knob");
            stairs = new Room("stairs", "wooden bannister");
            upstairsHallway = new RoomWithHidingPlace("upstairs hallway", "a picture of a dog", "in the closet");
            masterBedroom = new RoomWithHidingPlace("master bedroom", "a large bed", "under the bed");
            secondBedroom = new RoomWithHidingPlace("second bedroom", "a small bed", "under the bed");
            bathroom = new RoomWithHidingPlace("bathroom", "a sink and a toilet", "in the shower");
            garden = new OutsideWithHidingPlace("garden", false, "in the shed");
            driveway = new OutsideWithHidingPlace("driveway", false, "in the garage");
            opponent = new Opponent(livingRoom);

            livingRoom.Exits = new Location[] { stairs, diningRoom };
            kitchen.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { kitchen, livingRoom };
            backYard.Exits = new Location[] { frontYard, garden, driveway };
            frontYard.Exits = new Location[] { backYard, garden, driveway };
            garden.Exits = new Location[] { frontYard, backYard };
            stairs.Exits = new Location[] { livingRoom, upstairsHallway };
            upstairsHallway.Exits = new Location[] { stairs, masterBedroom, secondBedroom, bathroom };
            masterBedroom.Exits = new Location[] { upstairsHallway };
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathroom.Exits = new Location[] { upstairsHallway };
            driveway.Exits = new Location[] { frontYard, backYard };

            kitchen.DoorLocation = backYard;
            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
        }
    }
}