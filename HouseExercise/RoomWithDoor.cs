using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExercise
{
    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public Location DoorLocation { get; set; }
        private string doorDescription;
        public string DoorDescription
        {
            get
            {
                return doorDescription;
            }
        }
        public RoomWithDoor(string name, string decoration, string doorDesc) : base(name, decoration)
        {
            doorDescription = doorDesc;
        }
    }
}