using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExercise
{
    class OutsideWithHidingPlace : Outside, IHidingPlace
    {
        private string hidingPlace;
        public string HidingPlace
        {
            get
            {
                return hidingPlace;
            }
        }
        public bool Checked { get; set; }

        public OutsideWithHidingPlace(string name, bool hot, string hidingPlace) : base (name, hot) 
        {
            this.hidingPlace = hidingPlace;
        }

        public override string Description
        {
            get
            {
                return $"{base.Description}  Someone could hide {HidingPlace}.";
            }
        }

    }
}
