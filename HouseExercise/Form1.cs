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
        RoomWithDoor livingRoom, kitchen;
        OutsideWithDoor backYard, frontYard;
        Room diningRoom;
        Outside garden;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }

        private void CreateObjects()
        {
            livingRoom = new RoomWithDoor("Living Room", "an antique carpet", "an oak door with a brass knob");
            livingRoom.Exits = new Location[] { frontYard, diningRoom };

            kitchen = new RoomWithDoor("Kitchen", "stainless steel appliances", "a screen door");
            kitchen.Exits = new Location[] { backYard, diningRoom };

            diningRoom = new Room("Dining Room", "a crystal chandelier");
            diningRoom.Exits = new Location[] { kitchen, livingRoom };

            backYard = new OutsideWithDoor("Back Yard", true);
            backYard.Exits = new Location[] { kitchen, garden };

            frontYard = new OutsideWithDoor("Front Yard", false);
            frontYard.Exits = new Location[] { livingRoom, garden };

            garden = new Outside("Garden", false);
            garden.Exits = new Location[] { frontYard, backYard };
        }
    }
}
