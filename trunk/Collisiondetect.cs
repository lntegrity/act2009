﻿using Microsoft.Xna.Framework;
using System;

namespace ACT2009
{
    class Collisiondetect
    {
        void testCollisionarc()
        {
            
        }

        void writeCoordinates(Vector3 a)
        {
            System.Console.WriteLine("a: x="+a.X+" y="+a.Y);
        }

        //calculates collision and returns either the collisionarc or null of two 3D-Lines pressed down to z=0
        float getCollisionarc(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            float opt1 = d.Y - c.Y;
            float opt2 = c.Y - a.Y;
            float opt3 = b.X - a.X;
            float opt4 = b.Y - a.Y;
            float opt5 = c.X - a.X;
            float opt6 = d.X - c.X;
			float det1 = opt3*opt1 - opt4*opt6;
			float det2 = opt3*opt2 - opt4*opt5;
		
            if (det1 == 0)
            { // parallel
                if (det2 == 0)
                { // identical, colliding under 0 degree
                    return 0;
                }
                else
                { // really parallel, not crossing
                    //TODO: Must be extended to return corner and side or null
                    return 0;
                }
            }

            float lambda = (opt5*opt1 - opt2*opt6) / det1;
			float sigma  = -det2 / det1;


            if (lambda <= 1 && 0 <= lambda && sigma <= 1 && 0 <= sigma)
            {
                float xopt7 = b.X - a.X;
                float yopt7 = b.Y - a.Y;
                float xopt8 = d.X - c.X;
                float yopt8 = d.Y - c.Y;
                double opt9 = Math.Sqrt(yopt7 * yopt7 + xopt7 * xopt7);
                double opt10 = Math.Sqrt(yopt8 * yopt8 + xopt8 * xopt8);
                double opt11 = Math.Sqrt((xopt7 - xopt8) * (xopt7 - xopt8) + (yopt7 - yopt8) * (yopt7 - yopt8));
                return (float)Math.Acos((opt9*opt9 + opt10*opt10 - opt11*opt11) / (2 * opt9 * opt10));
            }

            //not colliding within borderlength
            //TODO: umformen!
            return 0;
        }
    }
}
