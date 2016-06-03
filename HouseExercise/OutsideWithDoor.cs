using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExercise
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
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
        public OutsideWithDoor(string name, bool hot, string doorDesc, Location doorLoc) : base(name, hot)
        {
            doorDescription = doorDesc;
            DoorLocation = doorLoc;
        }

        public override string Description
        {
            get
            {
                return $"{base.Description} You see {DoorDescription}.";
            }
        }
    }
}