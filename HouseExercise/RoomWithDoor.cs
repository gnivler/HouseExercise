using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExercise
{
    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
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
        public RoomWithDoor(string name, string decoration, string doorDesc, string hidingPlace) : base(name, decoration, hidingPlace)
        {
            doorDescription = doorDesc;
        }

        public override string Description
        {
            get
            {
                return $"{base.Description}  You see {DoorDescription}.";
            }
        }
    }
}