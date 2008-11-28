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


    }
}
