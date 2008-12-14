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
    /// <summary>
    /// This class provides the current user-orders through the controller and/or keyboard the car should follow
    /// </summary>
    public class Input
    {
        /// <summary>
        /// variable to hold the current acceleration buffering for multiple access
        /// </summary>
        private float Acceleration = 0.0f;
        /// <summary>
        /// variable to hold the current braking buffering for multiple access
        /// </summary>
        private float Brake = 0.0f;
        /// <summary>
        /// variable to hold the current direction buffering for multiple access
        /// </summary>
        private float Direction = 0.0f;

        /// <summary>
        /// Updating the Input
        /// </summary>
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);

            // resets the states
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
        
        /// <summary>
        /// returns accelleration between -1 (full reverse) and 1 (full forward)
        /// </summary>
        /// <returns>direction of accelleration</returns>
        public float GetAccelleration()
        {
            return Acceleration;
        }

        /// <summary>
        /// returns braking between 0 (none) and 1 (full)
        /// </summary>
        /// <returns>returns the intensity of braking from none (0) to full (1)</returns>
        public float GetBrake()
        {
            return Brake;
        }

        /// <summary>
        /// returns directions to steer right or left
        /// </summary>
        /// <returns>returns steering to the right (1), to the front (0) or to the left (-1)</returns>
        public float GetDirection()
        {
            return Direction;
        }

        /*/returns pause status false (play) and true (game paused)
        public bool GetPause()
        {
            return false;
        }
         */
    }
}
