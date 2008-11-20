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
        //absolute position the car is at (in meters)
        Vector3 position = new Vector3(0);
        //direction the car is looking at
        Vector3 direction = new Vector3(0);
        //velocity the car is currently moving at (kilometers per hour)
        float speed = 0;
        //color the car is painted in
        Color color = Color.Blue;
        //maximum velocity moving forward (kilometers per hour)
        float maxSpeedFwd = 50;
        //maximum velocity moving backward (kilometers per hour)
        float maxSpeedRew = 15;
        //weight of the car (kilogram)
        float weight = 300;
        //controller the car listens to
        Input controller = null;

        //initializes the car's data
        Car(Input contr)
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
            return position;
        }

        //sets the direction the car looks at
        public void SetDirection(Vector3 pos)
        {
            position = pos;
        }

        //returns the current speed of the car in km/h
        public float GetSpeed()
        {
            return speed;
        }

        //sets the current speed of the car in km/h
        public void SetDirection(float spd)
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
