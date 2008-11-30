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
        private float Acceleration = 0.0f;
        private float Brake = 0.0f;
        private float Direction = 0.0f;
        private bool pause = false;

        //constructor is subject to change
        public Input()
        {
        }

        //Updating the Input
        public void Update(KeyboardState keyboardState, GamePadState gamePad)
        {
            // set the states back
            Direction = 0.0f;
            Acceleration = 0.0f;
            Brake = 0.0f;

            // Check for Input
            if(gamePad.IsConnected)
            {
                Direction = gamePad.ThumbSticks.Left.X;
                if (gamePad.IsButtonDown(Buttons.A))
                {
                    Acceleration = 1.0f;
                }
                else if (gamePad.IsButtonDown(Buttons.B))
                {
                    Acceleration = -1.0f;
                }

                if(gamePad.IsButtonDown(Buttons.X))
                {
                    Brake = 1.0f;
                }
            }

            if(keyboardState.IsKeyDown(Keys.Left))
            {
                Direction = -1.0f;
            }
            else if(keyboardState.IsKeyDown(Keys.Right))
            {
                Direction = 1.0f;
            }

            if(keyboardState.IsKeyDown(Keys.Space))
            {
                Acceleration = 1.0f;
            }
            else if(keyboardState.IsKeyDown(Keys.LeftAlt))
            {
                Acceleration = -1.0f;
            }

            if(keyboardState.IsKeyDown(Keys.RightAlt))
            {
                Brake = 1.0f;
            }

        }
        
        //returns accelleration between -1 (full reverse) and 1 (full forward)
        public float GetAccelleration()
        {
            return Acceleration;
        }

        //returns braking between 0 (none) and 1 (full)
        public float GetBrake()
        {
            return Brake;
        }

        //returns accelleration between -1 (left) and 1 (right)
        public float GetDirection()
        {
            return Direction;
        }

        //returns pause status false (play) and true (game paused)
        public bool GetPause()
        {
            return false;
        }
    }
}
