// Project: ACT2009, File: Car.cs
// Namespace: ACT2009, Class: Car
// Path: \ACT2009\Car
// Author: Claus Wollnik, Team 2
// Used to handle the cardata in one place
// Creation date: 19.11.2008 19:06
// Last modified: 20.11.2008 20:15


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ACT2009
{
    /// <summary>
    /// This class contains all Car-dependant data to be handled by multiple parts of the game
    /// </summary>
    public class Car
    {
        /// <summary>
        /// predefined corner of the car (for collisionhandling)
        /// </summary>
        public const int FRONTLEFT = 1;
        /// <summary>
        /// predefined corner of the car (for collisionhandling)
        /// </summary>
        public const int FRONTRIGHT = 2;
        /// <summary>
        /// predefined corner of the car (for collisionhandling)
        /// </summary>
        public const int BACKLEFT = 3;
        /// <summary>
        /// predefined corner of the car (for collisionhandling)
        /// </summary>
        public const int BACKRIGHT = 4;

        /// <summary>
        /// corner which had a collision, 0 if no collision
        /// </summary>
        private int collisionCorner = 0;
        /// <summary>
        /// arc at which the collision has occured
        /// </summary>
        private float collisionArc = 0;
        /// <summary>
        /// line at which the car collided (for reflecting)
        /// </summary>
        private Vector3 collisionLine = new Vector3(0);
        /// <summary>
        /// dimensions of the Car
        /// </summary>
        private Vector3 dimension = new Vector3(1.5f, 1.5f, 2.0f);
        /// <summary>
        /// absolute position the car is at (in meters, bottom-middle of the car)
        /// </summary>
        private Vector3 position = new Vector3(0);
        /// <summary>
        /// direction the car is looking at
        /// </summary>
        private Vector3 direction = new Vector3(0);
        /// <summary>
        /// velocity the car is currently moving at (kilometers per hour)
        /// </summary>
        private float speed = 0;
        /// <summary>
        /// color the car is painted in
        /// </summary>
        private Color color = Color.Blue;
        /// <summary>
        /// maximum velocity moving forward (kilometers per hour)
        /// </summary>
        private float maxSpeedFwd = 90;
        /// <summary>
        /// maximum velocity moving backward (kilometers per hour)
        /// </summary>
        private float maxSpeedRew = -30;
        /// <summary>
        /// weight of the car (kilogram)
        /// </summary>
        private float weight = 300;
        /// <summary>
        /// controller the car listens to
        /// </summary>
        private Input controller = null;
		/// <summary>
        /// maximum acceleration (meters per second squared)
		/// </summary>
		private float maxAcceleration = 7.5f;
		/// <summary>
        /// maxumum negative acceleration (braking) (meters per second square)
		/// </summary>
		private float maxBraking = 9.0f;


        /// <summary>
        /// initializes the car in constructor
        /// </summary>
        /// <param name="contr">reference of the input-handler</param>
        public Car(ref Input contr)
        {
            //can only be set in constructor
            controller = contr;
        }

        /// <summary>
        /// initializes the car in constructor
        /// </summary>
        /// <param name="contr">reference of the input-handler</param>
        /// <param name="clr">color of the car</param>
        Car(ref Input contr, Color clr)
        {
            //can only be set in constructor
            color = clr;

            //can only be set in constructor
            controller = contr;
        }

        /// <summary>
        /// initializes the car in constructor
        /// </summary>
        /// <param name="contr">reference of the input-handler</param>
        /// <param name="clr">color of the car</param>
        /// <param name="wgt">weight (in kilogram) of the car</param>
        Car(ref Input contr, Color clr, float wgt)
        {

            //can only be set in constructor
            color = clr;

            //can only be set in constructor
            controller = contr;

            //can only be set in constructor
            weight = wgt;
        }

        /// <summary>
        /// sets the corner which had a collision, 0 if no collision occured
        /// </summary>
        /// <param name="crnr">predefined constant of the corner or 0 if none</param>
        public void SetCollisionCorner(int crnr)
        {
            collisionCorner = crnr;
        }

        /// <summary>
        /// returns the corner which had a collision, 0 if no collision occured
        /// </summary>
        /// <returns>predefined constant of the corner or 0 if none</returns>
        public int GetCollisionCorner()
        {
            return collisionCorner;
        }

        /// <summary>
        /// sets the arc at which the collision has occured
        /// </summary>
        /// <param name="cllArc">the arcus under which the collision occured</param>
        public void SetCollisionArc(float cllArc)
        {
            collisionArc = cllArc;
        }

        /// <summary>
        /// returns the arc at which the collision has occured
        /// </summary>
        /// <returns>arcus under which the collision has occured</returns>
        public float GetCollisionArc()
        {
            return collisionArc;
        }

        /// <summary>
        /// Sets the line at which the car collided (for reflecting)
        /// </summary>
        /// <param name="cllLine">Point paired with point (0,0,0) to describe how the line lies in space</param>
        public void SetCollisionLine(Vector3 cllLine)
        {
            collisionLine = cllLine;
        }

        /// <summary>
        /// Returns the line at which the car collided (for reflecting)
        /// </summary>
        /// <returns>Point paired with point (0,0,0) to describe how the line lies in space</returns>
        public Vector3 SetCollisionLine()
        {
            return collisionLine;
        }

        /// <summary>
        /// returns the dimensions of the Car
        /// </summary>
        /// <returns>Size of the car</returns>
        public Vector3 GetDimension()
        {
            return dimension;
        }
        
        /// <summary>
        /// returns the highest possible acceleration of the car
        /// </summary>
        /// <returns>maximum possible accelleration in meter per secondsquare</returns>
        public float GetMaxAcceleration()
        {
            return maxAcceleration;
        }

        /// <summary>
        /// sets the highest possible acceleration of the car
        /// </summary>
        /// <param name="macc">maximum possible accelleration in meter per secondsquare</param>
        public void SetMaxAcceleration(float macc)
        {
            maxAcceleration = macc;
        }
		
		/// <summary>
        /// returns the highest possible braking of the car
		/// </summary>
        /// <returns>maximum possible braking in meter per secondsquare</returns>
        public float GetMaxBraking()
        {
            return maxBraking;
        }

        /// <summary>
        /// sets the highest possible braking of the car
        /// </summary>
        /// <param name="mbrac">maximum possible braking in meter per secondsquare</param>
        public void SetMaxBraking(float mbrac)
        {
            maxBraking = mbrac;
        }
		
        /// <summary>
        /// returns the current absolute position of the car
        /// </summary>
        /// <returns>position of the car</returns>
        public Vector3 GetPosition()
        {
            return position;
        }

        /// <summary>
        /// sets a new absolute position of the car
        /// </summary>
        /// <param name="pos">position of the car</param>
        public void SetPosition(Vector3 pos)
        {
            position = pos;
        }

        /// <summary>
        /// returns the vector the car directs at
        /// </summary>
        /// <returns>direction of the car</returns>
        public Vector3 GetDirection()
        {
            return direction;
        }

        /// <summary>
        /// sets the direction the car looks at
        /// </summary>
        /// <param name="dir">direction of the car</param>
        public void SetDirection(Vector3 dir)
        {
            direction = dir;
        }

        /// <summary>
        /// returns the current speed of the car in km/h
        /// </summary>
        /// <returns>speed of the car in kilometers per hour</returns>
        public float GetSpeed()
        {
            return speed;
        }

        /// <summary>
        /// sets the current speed of the car in km/h
        /// </summary>
        /// <param name="spd">speed of the car in kilometers per hour</param>
        public void SetSpeed(float spd)
        {
            speed = spd;
        }

        /// <summary>
        /// returns the color of the car
        /// </summary>
        /// <returns>color of the car</returns>
        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// returns the maximum forward velocity of the car in km/h
        /// </summary>
        /// <returns>maximum forward speed of the car in kilometers per hour</returns>
        public float GetMaxSpeedFwd()
        {
            return maxSpeedFwd;
        }

        /// <summary>
        /// sets the maximum forward velocity of the car in km/h
        /// </summary>
        /// <param name="spd">maximum forward speed of the car in kilometers per hour</param>
        public void SetMaxSpeedFwd(float spd)
        {
            maxSpeedFwd = spd;
        }

        /// <summary>
        /// returns the maximum reverse velocity of the car in km/h
        /// </summary>
        /// <returns>maximum reverse speed of the car in kilometers per hour</returns>
        public float GetMaxSpeedRew()
        {
            return maxSpeedRew;
        }

        /// <summary>
        /// sets the maximum reverse velocity of the car in km/h
        /// </summary>
        /// <param name="spd">maximum reverse speed of the car in kilometers per hour</param>
        public void SetMaxSpeedRew(float spd)
        {
            maxSpeedRew = spd;
        }

        /// <summary>
        /// returns the weight of the car in kilogram
        /// </summary>
        /// <returns>weight of the car in kilogram</returns>
        public float GetWeight()
        {
            return weight;
        }

        /// <summary>
        /// returns the controller the car listens to
        /// </summary>
        /// <returns>controller that controls the car</returns>
        public Input GetController()
        {
            return controller;
        }

        /// <summary>
        /// Updating the corresponding input and sounds
        /// </summary>
        public void Update()
        {
            controller.Update();
            
            /*
             * 1. das motorgeräusch: die tonhöhe (pitch) abhängig von der geschwindigkeit/maximale geschwindigkeit
             * 2. Kollisionsgeräusch abspielen, wenn die Kollisionsvariable auf true steht
             * 3. bei Lenkvolleinschlag (input.getDirection() oder so ähnlich auf 1 oder -1) quietschgeräusche abspielen
             *       nur, wenn die geschwindigkeit ungleich 0 ist
            */
            // Tonhoehe abhaengig von Geschwindigkeit
            /*
            if (speed == maxSpeedFwd || speed == maxSpeedRew)
            {
                //Console.WriteLine("I'm printing in speed==maxSpeedFwd||speed==maxSpeedBwd " + speed);
                float pitch = 1;
                Sounds.getFinalDriveSEI().Stop();
                Sounds.PlayFinalDriveSound(pitch, true);
            }
            if (speed < maxSpeedFwd && speed > 0)
            {

                //Console.WriteLine("I'm printing in speed<maxSpeedFwd" + speed);
                //float pitch = speed / maxSpeedFwd;
                Sounds.getFinalDriveSEI().Stop();
                Sounds.PlayFinalDriveSound(pitch, true);
 
            }
            if (speed == 0 && Sounds.getFinalDriveSEI() != null)
            {
                //Console.WriteLine("Stopping Sound");
                Sounds.getFinalDriveSEI().Stop();

            }*/

            //Kollission
            if (collisionCorner!=0)
            {
                Sounds.PlayBangSound(false);
            }
            
            // Lenken
            //Console.WriteLine("Direction:" + controller.GetDirection());
            if ((controller.GetDirection() == 1 || controller.GetDirection() == -1) && (speed != 0))
            {
                //Console.WriteLine("Direction:" + controller.GetDirection());
                if (Sounds.getBrakesSEI()==null)
                {
                    Sounds.PlayBrakesSound(false);
                }
            }
            if (controller.GetDirection() == 0)
            {
                if (Sounds.getBrakesSEI() != null)
                {
                    //Console.WriteLine("Stop BRAKES");
                    Sounds.getBrakesSEI().Stop();
                    Sounds.setBrakesSEI(null);
                }
            }
            
        }

        /// <summary>
        /// calculates the corner defined by the constant given
        /// </summary>
        /// <param name="corner">const value describing one of the cars corners</param>
        /// <returns>position of the given corner</returns>
        public Vector3 getCorner(int corner)
        {
            Vector3 cornerPos = new Vector3();
            Vector3 r = direction;
            r.Normalize();
            Vector3 r2 = new Vector3(-r.Z, 0, r.X);
            Vector3 L = r*dimension.X/2;
            Vector3 B = r2*dimension.Z/2;

            switch (corner)
            {
                case Car.FRONTLEFT:
                    cornerPos = position + L - B;
                    break;
                case Car.FRONTRIGHT: 
                    cornerPos = position + L + B;
                    break;
                case Car.BACKLEFT: 
                    cornerPos = position - L - B;
                    break;
                case Car.BACKRIGHT: 
                    cornerPos = position - L + B;
                    break;
            }
            return cornerPos;
        }
    }
}
