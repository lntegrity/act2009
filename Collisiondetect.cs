using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace ACT2009
{
    class Collisiondetect
    {
        //inner Border
        ModelPositions innerBorder;
        //outer Border
        ModelPositions outerBorder;

        Car car;
        //Maximum Distance allowed to use point for collision detection
        //float distanceLimit;


        public Collisiondetect(Car c, ModelPositions innerBorder, ModelPositions outerBorder)
        {
            car = c;
            this.innerBorder = innerBorder;
            this.outerBorder = outerBorder;
        }

        //@param arc: arcus under wich the collision occured, if any
        private bool SweepPoints(ModelPositions border, Vector3 a, Vector3 b, ref float arc)
        {
            for (int i=0; i+1 < border.GetCount(); ++i)
            {
                if (getCollisionarc(a, b, border.getPosition(i), border.getPosition(i + 1), ref arc))
                {
                    return true;
                }
            }
            return getCollisionarc(a, b, border.getPosition(border.GetCount()-1), border.getPosition(0), ref arc);
        }

        //tests every position-pair of inner and outer border if it collided with a car-constraint
        public void detectCollision()
        {
            //car.ResetCollision();
            car.SetCollisionCorner(0);

            //Collisionarc on the side
            float arcSide = 0;
            //Collisionarc on front or back
            float arcFront = 0;

            bool frontCollision = false;
            bool rightCollision = false;
            bool leftCollision = false;
            bool rearCollision = false;

            frontCollision = SweepPoints(innerBorder, car.getCorner(Car.FRONTLEFT), car.getCorner(Car.FRONTRIGHT), ref arcFront)
                                || SweepPoints(outerBorder, car.getCorner(Car.FRONTLEFT), car.getCorner(Car.FRONTRIGHT), ref arcFront);

            rightCollision = SweepPoints(innerBorder, car.getCorner(Car.FRONTRIGHT), car.getCorner(Car.BACKRIGHT), ref arcSide)
                                || SweepPoints(outerBorder, car.getCorner(Car.FRONTRIGHT), car.getCorner(Car.BACKRIGHT), ref arcSide);

            rearCollision = SweepPoints(innerBorder, car.getCorner(Car.BACKRIGHT), car.getCorner(Car.BACKLEFT), ref arcFront)
                                || SweepPoints(outerBorder, car.getCorner(Car.BACKRIGHT), car.getCorner(Car.BACKLEFT), ref arcFront);

            leftCollision = SweepPoints(innerBorder, car.getCorner(Car.BACKLEFT), car.getCorner(Car.FRONTLEFT), ref arcSide)
                                || SweepPoints(outerBorder, car.getCorner(Car.BACKLEFT), car.getCorner(Car.FRONTLEFT), ref arcSide);

            if (frontCollision)
            {
                if (rightCollision)
                {
                    car.SetCollisionArc(arcSide);
                    car.SetCollisionCorner(Car.FRONTRIGHT);
                }
                else if (leftCollision)
                {
                    car.SetCollisionArc(arcSide);
                    car.SetCollisionCorner(Car.FRONTLEFT);
                }
                else
                {
                    car.SetCollisionArc((float)(System.Math.PI / 2));
                    car.SetCollisionCorner(Car.FRONTLEFT);
                }
            }
            else if (rearCollision)
            {
                if (rightCollision)
                {
                    car.SetCollisionArc((float)System.Math.PI - arcSide);
                    car.SetCollisionCorner(Car.FRONTRIGHT);
                }
                else if (leftCollision)
                {
                    car.SetCollisionArc((float)System.Math.PI - arcSide);
                    car.SetCollisionCorner(Car.FRONTLEFT);
                }
                else
                {
                    car.SetCollisionArc((float)(System.Math.PI / 2));
                    car.SetCollisionCorner(Car.FRONTLEFT);
                }
            }
        }

        //calculates collision and returns either the collisionarc or null of two 3D-Lines pressed down to z=0
        private bool getCollisionarc(Vector3 a, Vector3 b, Vector3 c, Vector3 d, ref float arc)
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
                    arc = 0;
                    return true;
                }
                else
                { // really parallel, not crossing
                    return false;
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
                double opt9 = System.Math.Sqrt(yopt7 * yopt7 + xopt7 * xopt7);
                double opt10 = System.Math.Sqrt(yopt8 * yopt8 + xopt8 * xopt8);
                double opt11 = System.Math.Sqrt((xopt7 - xopt8) * (xopt7 - xopt8) + (yopt7 - yopt8) * (yopt7 - yopt8));
                arc = (float)System.Math.Acos((opt9 * opt9 + opt10 * opt10 - opt11 * opt11) / (2 * opt9 * opt10));
                return true;
            }

            //not colliding within borderlength
            return false;
        }
    }
}