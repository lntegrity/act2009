// Project: ACT2009, File: Physics.cs
// Namespace: ACT2009, Class: Game1
// Path: \ACT2009\Physics.cs
// Author: Tobias Feigel, Team 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace ACT2009
{

    /// <summary>
    /// This class recalculates the position, direction and speed depending on the input and the car status
    /// </summary>
    public class Physics
    #region Variablen
    { 
        //Defines some neccessary parameters and set parameters for the use in the class 
    
        // parameters from class Input
        private Input input;
        private float InputAcceleration;                    
        private float InputCarBrake;                       
        private float InputCarDirection;

        // parameters from class Car
        private Vector3 oldPosition;
        private Vector3 oldDirection;
        private float oldSpeed;
        private float maxAcc;
        private float maxBrak;
        private float Weight;
        private float SpeedMax;
        private float SpeedMaxRev;
        private int CollisionCorner;
        private float CollisionArc;

        // physical constants and other parameters
        private const float g = 9.81f;
        private const float my = 0.45f;
        private Car pCart;
        private float t;
        private float oldt;
    #endregion

        #region Konstruktor
        public Physics(ref Car cart)
        
        {
            // set car and input
            pCart=cart;
            input = pCart.GetController();
        }
        #endregion

        /// <summary>
        /// Update handels the Userinput which will be set by the class Input and calls the
        /// internal method to handle the Input.
        /// </summary>
        #region Update

        public void Update(GameTime gtime)
        {
            // get parameters from different classes and set them to the internal parameters
            InputAcceleration = input.GetAccelleration();
            InputCarBrake = input.GetBrake();
            InputCarDirection = input.GetDirection();
            maxAcc = pCart.GetMaxAcceleration();
            maxBrak = pCart.GetMaxBraking();

            oldPosition = pCart.GetPosition();
            oldDirection = pCart.GetDirection();
            oldSpeed = pCart.GetSpeed();
            Weight = pCart.GetWeight();
            SpeedMax = pCart.GetMaxSpeedFwd();
            SpeedMaxRev = pCart.GetMaxSpeedRew();

            // parameters neccessary for collisiondetection
            CollisionCorner = pCart.GetCollisionCorner();
            CollisionArc = pCart.GetCollisionArc();

            // get elapsed time since last update
            t = (float) gtime.ElapsedGameTime.Milliseconds/1000f;
            oldt = gtime.TotalGameTime.Milliseconds/1000f;
            
            // if user accelerates, call this methods
            if (InputAcceleration != 0)
            {
                this.Accelerate();
                this.Stear();
            }

            // if user stears but do not accelerate, call this methods
            if (InputCarDirection != 0 && InputAcceleration == 0)
            {
                this.noInput();
                this.Stear();
            }
            
            // if there is no userinput, call method noInput which handels Friction
            if (InputCarDirection == 0 && InputAcceleration == 0)
            {
                this.noInput();
            }

            // if user brakes call method brake
            if (InputCarBrake != 0)
            {
                this.Brake();
            }

            // if there was a collision call HandleCollision
            if (CollisionCorner != 0)
            {
                this.HandleCollision();
            }
        }
        #endregion

        /// <summary>
        /// accelerate handels acceleration by the user
        /// </summary>
        #region Accelerate
        private void Accelerate()
        {
            // calculate new speed
            float speed = 0;

            if (InputAcceleration != 0)
            {
                speed = oldSpeed + Math.KMperHour((a(InputAcceleration, maxAcc) * t));
            }

            // check speed and set it at the actual cart
            speed = speedCheck(speed);
            pCart.SetSpeed(speed);

            // no new direction, only acceleration
            Vector3 v_direction = new Vector3();
            v_direction = oldDirection;

            // if cart drives calculate new position
            if (speed != 0)
            {
                // calculate new position and set at the actual cart
                Vector3 v_position = new Vector3();
                v_position = (Math.MeterPerSecond(speed) * v_direction * t) + oldPosition;
                pCart.SetPosition(v_position);
            }
        }
        #endregion

        /// <summary>
        /// If user brakes handle it and renew position and speed
        /// </summary>
        /// <param name="maxBrake">maximum of negative acceleration</param>
        #region Brake
        private void Brake()
        {
            float speed;

            // If speed is zero then return
            if (oldSpeed == 0)
                return;

            // does the cart drive foreward or backward?
            if (oldSpeed > 0)
            {
                maxBrak = maxBrak - 2 * maxBrak;
            }

            // calculate new speed 
            speed = oldSpeed + Math.KMperHour((a(InputCarBrake, maxBrak) * t));

            // if speed changes between positiv and negativ or backward then set speed to zero
            if ((oldSpeed < 0 && speed > 0)||(oldSpeed > 0 && speed < 0))
            {
                speed = 0;
            }

            pCart.SetSpeed(speed);

            // calculate new position and set at the cart
            Vector3 v_direction = new Vector3();
            v_direction = oldDirection;

            // calculate new position and set it
            Vector3 v_position = new Vector3();
            v_position = (Math.MeterPerSecond(speed) * v_direction * t) + oldPosition;
            pCart.SetPosition(v_position);
        }
        #endregion

        /// <summary>
        /// noInput calculates speed und position if there is no userinput
        /// </summary>
        #region noInput
        private void noInput()
        {
            float speed;

            if (oldSpeed == 0)
                return;

            // calculate new speed
            speed = oldSpeed + Math.KMperHour((a(0, 0) * t));
            
            
            // if speed was zero between the calculation stop cart
            if ((oldSpeed < 0 && speed > 0)||(oldSpeed > 0 && speed < 0))
            {
                speed = 0;
            }
            
            // calculate and set speed
                speed = speedCheck(speed);
                pCart.SetSpeed(speed);

            // calculate and set position and direction
            Vector3 v_position = new Vector3();
            Vector3 v_direction = new Vector3();
            v_direction = oldDirection;
            v_position = (Math.MeterPerSecond(speed) * v_direction * t) + oldPosition;
            pCart.SetPosition(v_position);

        }
        #endregion

        /// <summary>
        /// Calculate new parameters if the user stears
        /// </summary>
        #region Stear
        private void Stear()
        {
            // angle to rotate direction
            float Angle = 0f;

            // drives the cart foreward, backward or not
            if (oldSpeed > 0)
            {
                Angle = InputCarDirection * -1.2f * t;
            }
            else if (oldSpeed < 0)
            {
                Angle = InputCarDirection * 1.2f * t;
            }
            else
            {
                return;
            }

            double x;
            double y;
            float oldx;
            float oldy;
            Vector3 vektor;

            // get old direction
            oldx = oldDirection.Z;
            oldy = oldDirection.X;

            // calculate new direction
            x = oldx * System.Math.Cos(Angle) - oldy * System.Math.Sin(Angle);
            y = oldy * System.Math.Cos(Angle) + oldx * System.Math.Sin(Angle);

            // cast new coordinates
            oldx = (float) x;
            oldy = (float) y;

            // set new vector
            vektor = new Vector3(oldy, 0f, oldx);
            pCart.SetDirection(vektor);
        }
        #endregion

        /// <summary>
        /// Returns the vector of the resulting Force.  
        /// </summary>
        /// <param name="Acc">Acceleration between -1 and 1</param>
        /// <param name="max">maximum acceleration of the cart</param>
        /// <returns>vector which contains resulting Force</returns>
        #region v_Fres
        private Vector3 v_Fres(float Acc, float max)
        {
            float x;
            float y;
            float z;
            float temp;

            // calculates resulting Force between 0 and 1
            if (Acc != 0 || oldSpeed != 0)
            {
                temp = Fres_y(Acc, max) / System.Math.Abs(Weight * Acc * max);
            }
            else
            {
                temp = oldDirection.X;
            }

            // calculate coordinates of the vector
            x = temp;
            y = 0;
            z = InputCarDirection;


            // create and set new vector
            Vector3 vektor = new Vector3(x, y, z);
            
            // normalize vector if possible
            if (vektor.X != 0 || vektor.Y != 0 || vektor.Z != 0)
                vektor = Vector3.Normalize(vektor);
            return vektor;
        }
        #endregion

        /// <summary>
        /// calculates acceleration forced to the cart
        /// </summary>
        /// <param name="Acc">Acceleration between -1 and 1</param>
        /// <param name="max">maximum acceleration for the cart</param>
        /// <returns>returns acceleration at cart</returns>
        #region a
        private float a(float Acc, float max)
        {
            float temp;
            float a;

            temp = Fres_y(Acc, max);
            a = temp / Weight;

            return a;

        }
        #endregion

        /// <summary>
        /// calculates resulting acceleration
        /// </summary>
        /// <param name="Acc">acceleration between -1 and 1</param>
        /// <param name="max">maximum acceleration</param>
        /// <returns>Force in Newton</returns>
        #region Fres_y
        private float Fres_y(float Acc, float max)
        {
            float Friction;
            float Force;
            float temp;

            // calculates forces for the cart
            Force = Weight * Acc * max;
            Friction = my * Weight * g;

            // calculate resulting force with Friction
            if (oldSpeed > 0)
            {
                temp = Force - Friction;
            }
            else if (oldSpeed < 0)
            {
                temp = Force + Friction;
            }
            else
            {
                if (max > 0 && Acc > 0)
                {
                    temp = Force - Friction;
                }
                else
                {
                    temp = Force + Friction;
                }
            }

            // return Force in Newton            
            return temp;
        }
        #endregion

        /// <summary>
        /// SpeedCheck checks if speed is higher then max or lower than min and sets speed
        /// to max or min if neccessary
        /// </summary>
        /// <returns>returns new speed</returns>
        #region SpeedCheck
        private float speedCheck(float speed)
        {
            // speed higher than max?
            if (speed > SpeedMax)
                speed = SpeedMax;
            // speed lower than min?
            else if (speed < SpeedMaxRev)
                speed = SpeedMaxRev;
            // retunr speed
            return speed;
        }
        #endregion

        /// <summary>
        /// HandleCollision: if there was a collision it will be handled here
        /// </summary>
        #region HandleCollision
        private void HandleCollision()
        {
            float Rotation;
            float Angle;
            double x;
            double y;
            float oldx;
            float oldy;
            Vector3 vektor;

            // collisions between 60° and 90° will stop car and causes total harm.
            // set speed
            if (CollisionArc < MathHelper.PiOver2 && CollisionArc > MathHelper.Pi / 3.0f)
            {
                pCart.SetSpeed(0.0f);
                Rotation = 0.0f;
            }
            // other angles will reduce speed and rotate cart
            else
            {
                pCart.SetSpeed(oldSpeed * 0.7f);
                
                // Rotation bestimmen
                Rotation = CollisionArc * 0.8f * t;
                if (CollisionCorner == Car.FRONTRIGHT || CollisionCorner == Car.BACKLEFT)
                {
                    Rotation = Rotation - 2 * Rotation;
                }

            }
            Angle = Rotation;

            // get old direction
            oldx = oldDirection.Z;
            oldy = oldDirection.X;

            // calculate new coordinates
            x = oldx * System.Math.Cos(Angle) - oldy * System.Math.Sin(Angle);
            y = oldy * System.Math.Cos(Angle) + oldx * System.Math.Sin(Angle);

            // cast new coordinates
            oldx = (float)x;
            oldy = (float)y;

            // set new vector
            vektor = new Vector3(oldy, 0f, oldx);
            pCart.SetDirection(vektor);
        }
        #endregion
    } 
}
