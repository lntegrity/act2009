﻿// Project: ACT2009, File: Car.cs
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
        //absolute position the car is at (in meters)
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
		
        //initializes the car's data
        public Car(Input contr)
        {
            //can only be set here
            controller = contr;
        }

        //initializes the car's data
        Car(Input contr, Color clr)
        {
            //can only be set here
            color = clr;

            //can only be set here
            controller = contr;
        }

        //initializes the car's data
        Car(Input contr, Color clr, float wgt)
        {
            //can only be set here
            color = clr;

            //can only be set here
            controller = contr;

            //can only be set here
            weight = wgt;
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
    }
}
