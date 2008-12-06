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
    class Car
    {
        //Input Input;

        //predefined corners of the car (for collisionhandling)
        public const int FRONTLEFT = 1;
        public const int FRONTRIGHT = 2;
        public const int BACKLEFT = 3;
        public const int BACKRIGHT = 4;

        //corner which had a collision, 0 if no collision
        private int collisionCorner = 0;
        //arc at which the collision has occured
        private float collisionArc = 0;
        //line at which the car collided (for reflecting)
        private Vector3 collisionLine = new Vector3(0);
        //dimensions of the Car
        private Vector3 dimension = new Vector3(1.5f, 1.5f, 2.0f);
        //absolute position the car is at (in meters, bottom-middle of the car)
        private Vector3 position = new Vector3(0);
        //direction the car is looking at
        private Vector3 direction = new Vector3(0);
        //velocity the car is currently moving at (kilometers per hour)
        private float speed = 0;
        //color the car is painted in
        private Color color = Color.Blue;
        //maximum velocity moving forward (kilometers per hour)
        private float maxSpeedFwd = 50;
        //maximum velocity moving backward (kilometers per hour)
        private float maxSpeedRew = 15;
        //weight of the car (kilogram)
        private float weight = 300;
        //controller the car listens to
        private Input controller = null;
		//maximum acceleration (meters per second squared)
		private float maxAcceleration = 6.9f;
		//maxumum negative acceleration (braking) (meters per second square)
		private float maxBraking = 8.0f;

        //initializes the car's in constructor
        public Car(ref Input contr)
        {
            //can only be set in constructor
            controller = contr;
        }

        //initializes the car's data
        Car(Input contr, Color clr)
        {
            //can only be set in constructor
            color = clr;

            //can only be set in constructor
            controller = contr;
        }

        //initializes the car's data
        Car(Input contr, Color clr, float wgt)
        {

            //can only be set in constructor
            color = clr;

            //can only be set in constructor
            controller = contr;

            //can only be set in constructor
            weight = wgt;
        }

        //sets the corner which had a collision, 0 if no collision occured
        public void SetCollisionCorner(int crnr)
        {
            collisionCorner = crnr;
        }

        //returns the corner which had a collision, 0 if no collision occured
        public int GetCollisionCorner()
        {
            return collisionCorner;
        }

        //sets the arc at which the collision has occured
        public void SetCollisionArc(float cllArc)
        {
            collisionArc = cllArc;
        }

        //returns the arc at which the collision has occured
        public float GetCollisionArc()
        {
            return collisionArc;
        }

        //Sets the line at which the car collided (for reflecting)
        public void SetCollisionLine(Vector3 cllLine)
        {
            collisionLine = cllLine;
        }

        //Returns the line at which the car collided (for reflecting)
        public Vector3 SetCollisionLine()
        {
            return collisionLine;
        }

        //returns the dimensions of the Car
        public Vector3 GetDimension()
        {
            return dimension;
        }
        
        //returns the highest possible acceleration of the car
        public float GetMaxAcceleration()
        {
            return maxAcceleration;
        }

        //sets the highest possible acceleration of the car
        public void SetMaxAcceleration(float macc)
        {
            maxAcceleration = macc;
        }
		
		//returns the highest possible braking of the car
        public float GetMaxBraking()
        {
            return maxBraking;
        }

        //sets the highest possible braking of the car
        public void SetMaxBraking(float mbrac)
        {
            maxBraking = mbrac;
        }
		
        //returns the current absolute position of the car
        public Vector3 GetPosition()
        {
            return position;
        }

        //sets a new absolute position of the car
        public void SetPosition(Vector3 pos)
        {
            position = pos;
        }

        //returns the vector the car directs at
        public Vector3 GetDirection()
        {
            return direction;
        }

        //sets the direction the car looks at
        public void SetDirection(Vector3 dir)
        {
            direction = dir;
        }

        //returns the current speed of the car in km/h
        public float GetSpeed()
        {
            return speed;
        }

        //sets the current speed of the car in km/h
        public void SetSpeed(float spd)
        {
            speed = spd;
        }

        //returns the color of the car
        public Color GetColor()
        {
            return color;
        }

        //returns the maximum forward velocity of the car in km/h
        public float GetMaxSpeedFwd()
        {
            return maxSpeedFwd;
        }

        //sets the maximum forward velocity of the car in km/h
        public void SetMaxSpeedFwd(float spd)
        {
            maxSpeedFwd = spd;
        }

        //returns the maximum reverse velocity of the car in km/h
        public float GetMaxSpeedRew()
        {
            return maxSpeedRew;
        }

        //sets the maximum reverse velocity of the car in km/h
        public void SetMaxSpeedRew(float spd)
        {
            maxSpeedRew = spd;
        }

        //returns the weight of the car in kilogram
        public float GetWeight()
        {
            return weight;
        }

        //returns the controller the car listens to
        public Input GetController()
        {
            return controller;
        }

        //Updating the corresponding input
        public void Update()
        {
            controller.Update();

            /**
             * 1. das motorgeräusch: die tonhöhe (pitch) abhängig von der geschwindigkeit/maximale geschwindigkeit
             * 2. Kollisionsgeräusch abspielen, wenn die Kollisionsvariable auf true steht
             * 3. bei Lenkvolleinschlag (input.getDirection() oder so ähnlich auf 1 oder -1) quietschgeräusche abspielen
             *       nur, wenn die geschwindigkeit ungleich 0 ist
            */
            // Tonhoehe abhaengig von Geschwindigkeit

            if (speed == maxSpeedFwd || speed == maxSpeedRew)
            {
                //Loud sound
            }
            if (speed < maxSpeedFwd&&speed>0)
            {
                float pitch = speed / maxSpeedFwd;

                Sounds.PlayFinalDriveSound(pitch, true);
            }
            if (speed < maxSpeedRew && speed > 0)
            {
                float pitch = speed / maxSpeedRew;
                Sounds.PlayFinalDriveSound(pitch, true);
            }



            //Kollission
            if (collisionCorner!=0)
            {
                Sounds.PlayBangSound(false);
            }

            // Lenken
            if((controller.GetDirection() ==1 || controller.GetDirection()==-1)&&(speed==0))
            {
                Sounds.PlayBrakesSound(false);
            }

        }

        //Return corners defined by static variables
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
