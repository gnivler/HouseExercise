﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExercise
{
    abstract class Location
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        public Location(string name)
        {
            Name = name;
        }

        public Location[] Exits;
        public string Name { get; private set; }       
        public virtual string Description
        {
            get
            {
                string description = $"You're standing in the {Name}.  You can go to the";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += $" {Exits[i].Name}";
                    if (i != Exits.Length -1)
                        description += " and";
                }
                description += ".";
                return description;
            }
        }
    }
}