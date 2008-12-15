using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ACT2009
{
    /// <summary>
    /// Helperclass for math calculations
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// converts km/h to m/s
        /// </summary>
        /// <param name="kmh">Speed in km/h</param>
        /// <returns>Speed in m/s</returns>
        public static float MeterPerSecond(float kmh)
        {
            float ms = (kmh * 1000)/3600;
            return ms;
        }

        /// <summary>
        /// converts m/s to km/h
        /// </summary>
        /// <param name="ms">Speed in m/s</param>
        /// <returns>Speed in km/h</returns>
        public static float KMperHour(float ms)
        {
            float kmh = (ms * 3600) / 1000;
            return kmh;
        }

        /// <summary>
        /// Calculates angle between two vectors
        /// </summary>
        /// <param name="vector1">vector one</param>
        /// <param name="vector2">vector two</param>
        /// <returns>angle between the vectors</returns>
        public static double getAngle(Vector3 vector1, Vector3 vector2)
        {
            double angle;
            double x1;
            double x2;
            double x3;

            x1 = Vector3.Dot(vector1, vector2);
            x2 = System.Math.Sqrt(System.Math.Pow(vector1.X, 2) + System.Math.Pow(vector1.Y, 2) + System.Math.Pow(vector1.Z, 2));
            x3 = System.Math.Sqrt(System.Math.Pow(vector2.X, 2) + System.Math.Pow(vector2.Y, 2) + System.Math.Pow(vector2.Z, 2));

            angle = System.Math.Acos(x1 / (x2 * x3));
            angle = angle * 180 / System.Math.PI;
            return angle;
        }


    }
}
