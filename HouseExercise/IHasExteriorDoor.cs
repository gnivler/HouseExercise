using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExercise
{
    interface IHasExteriorDoor
    {
        string DoorDescription { get; }
        string DoorLocation { get; set; }
    }
}
