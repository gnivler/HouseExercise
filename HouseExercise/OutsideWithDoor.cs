using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExercise
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public string DoorLocation { get; set; }
        private string doorDescription;
        public string DoorDescription
        {
            get
            {
                return doorDescription;
            }
        }
        public OutsideWithDoor(string name, bool hot, string description) : base(name, hot)
        {
            doorDescription = description;
        }
    }
}