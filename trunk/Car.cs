// Project: ACT2009, File: Car.cs
// Namespace: ACT2009, Class: Car
// Path: \ACT2009\Car
// Author: Claus Wollnik, Team 2
// Used to handle the cardata in one place
// Code lines: 225
// Creation date: 19.11.2008 19:06
// Last modified: 11.05.2008 13:15


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
        Vector3 position;
        //direction the car is looking at
        Vector3 direction;
        //velocity the car is currently moving at (kilometers per hour)
        float speed;
        //color the car is painted in
        Color color;
        //maximum velocity moving forward (kilometers per hour)
        float maxSpeedFwd;
        //maximum velocity moving backward (kilometers per hour)
        float maxSpeedRew;
        //weight of the car (kilogram)
        float weight;
        //controller the car listens to
        Input controller;

        //initializes the car's data
        Car(Input contr)
        {
            position = new Vector3(0);
            direction = new Vector3(0);
            speed = 0;
            color = Color.Blue;
            maxSpeedFwd = 50;
            maxSpeedRew = 15;
            weight = 300;
            controller = contr;
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
    }
}
