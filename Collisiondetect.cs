using Microsoft.Xna.Framework;
using System;

namespace ACT2009
{
    class Collisiondetect
    {
        //calculates collision and returns either the collisionarc or null of two 3D-Lines pressed down to z=0
        float getCollisionarc(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            if ((b.X - a.X)*(d.Y - c.Y) - (b.Y - a.Y)*(d.X - c.X) == 0)
            { // parallel
                if ((b.X - a.X)*(c.Y - a.Y) - (b.Y - a.Y)*(c.X - a.X) == 0)
                { // identical, colliding under 0 degree
                    return 0;
                }
                else
                { // really parallel, not crossing
                    //TODO: Must be extended to return corner and side or null
                    return 0;
                }
            }

            float lambda = ((c.X - a.X) * (d.Y - c.Y) - (c.Y - a.Y) * (d.X - c.X)) / ((b.X - a.X) * (d.Y - c.Y) - (b.Y - a.Y) * (d.X - c.X));
            float sigma;
            if (d.X == c.X) {
                sigma = (a.X - c.X + lambda*(b.X - a.X))/(d.X-c.X);
            } else {
                sigma = (a.Y - c.Y + lambda*(b.Y - a.Y))/(d.Y-c.Y);
            }

            if (lambda <= 1 && 0 <= lambda && 1 <= sigma && 0 <= sigma)
            {
                return (float)Math.Acos((Math.Pow(abs(sub(b, a)), 2) + Math.Pow(abs(sub(d, c)), 2) - Math.Pow(abs(sub(sub(b, a), sub(d, c))), 2)) / (2 * abs(sub(b, a)) * abs(sub(d, c))));
            }

            //not colliding within borderlength
            //TODO: umformen!
            return 0;
        }

        //helpermethod to calculate the distance between two points
        float abs(Vector3 o)
        {
            return  (float)Math.Sqrt(o.X*o.X + o.Y*o.Y);
        }

        Vector3 sub(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, 0);
        }
    }
}
