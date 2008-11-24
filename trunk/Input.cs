// Project: ACT2009, File: Input.cs
// Namespace: ACT2009, Class: Input
// Path: \ACT2009\Input
// Author: Claus Wollnik, Team 2
// Used to ease the request of carcontrols (needs to be completed, only skeleton)
// Creation date: 19.11.2008 19:10
// Last modified: 20.11.2008 20:53

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ACT2009
{
    class Input
    {
        //constructor is subject to change
        Input()
        {
        }
        
        //returns accelleration between -1 (full reverse) and 1 (full forward)
        public float GetAccelleration()
        {
            return 0;
        }

        //returns braking between 0 (none) and 1 (full)
        public float GetBrake()
        {
            return 0;
        }

        //returns accelleration between -1 (left) and 1 (right)
        public float GetDirection()
        {
            return 0;
        }

        //returns pause status false (play) and true (game paused)
        public bool GetPause()
        {
            return false;
        }
    }
}
