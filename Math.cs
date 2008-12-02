using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ACT2009
{
    /// <summary>
    /// Hilfsklasse, die Hilfsfunktionen bereitstellt
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Berechnung von km/h in m/s
        /// </summary>
        /// <param name="kmh">Geschwindigkeit in km/h</param>
        /// <returns>Geschwindigkeit in m/s</returns>
        public static float MeterPerSecond(float kmh)
        {
            float ms = (kmh * 1000)/3600;
            return ms;
        }

        /// <summary>
        /// Berechnung von m/s in km/h
        /// </summary>
        /// <param name="ms">Geschwindigkeit in m/s</param>
        /// <returns>Geschwindigkeit in km/h</returns>
        public static float KMperHour(float ms)
        {
            float kmh = (ms * 3600) / 1000;
            return kmh;
        }

        /// <summary>
        /// Berechnet den Winkel zwischen zwei Vektoren
        /// </summary>
        /// <param name="vector1">Erster Vektor</param>
        /// <param name="vector2">Zweiter Vektor</param>
        /// <returns>Winkel in Winkelgrad</returns>
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
