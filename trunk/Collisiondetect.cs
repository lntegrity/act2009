using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACT2009
{
    class Collisiondetect
    {
        //calculates collision and returns either the collisionarc or null of two 3D-Lines pressed down to z=0
        float getCollisionarc(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            if ((b[0] - a[0])*(d[1] - c[1]) - (b[1] - a[1])*(d[0] - c[0]) == 0)
            { // parallel
                if ((b[0] - a[0])*(c[1] - a[1]) - (b[1] - a[1])*(c[0] - a[0]) == 0)
                { // identical, colliding under 0 degree
                    return 0;
                }
                else
                { // really parallel, not crossing
                    return null;
                }
            }

            float lambda = ((c[0] - a[0]) * (d[1] - c[1]) - (c[1] - a[1]) * (d[0] - c[0])) / ((b[0] - a[0]) * (d[1] - c[1]) - (b[1] - a[1]) * (d[0] - c[0]));
            float sigma;
            if (d[0] - c[0]) {
                sigma = (a[0] - c[0] + lambda*(b[0] - a[0]))/(d[0]-c[0]);
            } else {
                sigma = (a[1] - c[1] + lambda*(b[1] - a[1]))/(d[1]-c[1]);
            }

            if (lambda <= 1 && 0 <= lambda && 1 <= sigma && 0 <= sigma)
            {
                return arccos((abs(sub(b, a)) ^ 2 + abs(sub(d, c)) ^ 2 - abs(sub(sub(b, a), sub(d, c))) ^ 2) / (2 * abs(sub(b, a)) * abs(sub(d, c))));
            }

            //not colliding within borderlength
            return null;
        }

        //helpermethod to calculate the distance between two points
        float abs(Vector3 o)
        {
            return sqrt((o.x)^2 + (o.y)^2);
        }

        Vector3 sub(Vector3 a, Vector3 b)
        {
            return Vector3(a[0] - b[0], a[1] - b[1], 0);
        }
    }
}
