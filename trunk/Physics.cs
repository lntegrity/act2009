// Project: ACT2009, File: Physics.cs
// Namespace: ACT2009, Class: Game1
// Path: \ACT2009\Physics.cs
// Author: Tobias Feigel, Team 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace ACT2009
{
    
    class Physics
    #region Variablen
    { 
        // Definiert Hilfsvariablen, die dann im Konstruktor gefüllt werden und zur
        // Verwendung in der Klasse bereitgestellt werden.

        // stellt Variablen für Werte der Inputklasse bereit
        private Input input;
        private float InputAcceleration;                    
        private float InputCarBrake;                       
        private float InputCarDirection;

        // stellt Variablen für Werte der Carklasse bereit
        private Vector3 oldPosition;
        private Vector3 oldDirection;
        private float oldSpeed;
        private float maxAcc;
        private float maxBrak;
        private float Weight;
        private float SpeedMax;
        private float SpeedMaxRev;
        private int CollisionCorner;
        private float CollisionArc;

        //stellt weitere Variablen und Constanten bereit:
        private const float g = 9.81f;
        private const float my = 0.45f;
        private Car pCart;
        private float t;
        private float oldt;
    #endregion

        #region Konstruktor
        public Physics(ref Car cart)
        
        {
            // setzt das Auto und die Eingabequelle
            pCart=cart;
            input = pCart.GetController();
        }
        #endregion

        /// <summary>
        /// Update wird aufgerufen um auf die Eingaben aus der Inputklasse zu reagieren und die
        /// entsprechende interne Funktionalität aufzurufen. 
        /// </summary>
        #region Update

        public void Update(GameTime gtime)
        {
            // holt alle nötigen Werte aus Car und Input
            InputAcceleration = input.GetAccelleration();
            InputCarBrake = input.GetBrake();
            InputCarDirection = input.GetDirection();
            maxAcc = pCart.GetMaxAcceleration();
            maxBrak = pCart.GetMaxBraking();

            oldPosition = pCart.GetPosition();
            oldDirection = pCart.GetDirection();
            oldSpeed = pCart.GetSpeed();
            Weight = pCart.GetWeight();
            SpeedMax = pCart.GetMaxSpeedFwd();
            SpeedMaxRev = pCart.GetMaxSpeedRew();

            // für CollisionDetection
            CollisionCorner = pCart.GetCollisionCorner();
            CollisionArc = pCart.GetCollisionArc();

            // ermittelt die vergangene Zeit seit letztem Update:
            t = (float) gtime.ElapsedGameTime.Milliseconds/1000f;
            oldt = gtime.TotalGameTime.Milliseconds/1000f;
            
            // wenn der Benutzer beschleunigt werden diese Methoden aufgerufen
            if (InputAcceleration != 0)
            {
                this.Accelerate();
                this.Stear();
            }

            // wenn der Benutzer lenkt aber nicht beschleunigt, werden diese Methoden aufgerufen
            if (InputCarDirection != 0 && InputAcceleration == 0)
            {
                this.noInput();
                this.Stear();
            }
            
            // erfolgt keine Benutzereingabe, dann ausrollen lassen!
            if (InputCarDirection == 0 && InputAcceleration == 0)
            {
                this.noInput();
            }

            // wenn der Benutzer bremst, dann wird die Bremsmethode aufgerufen
            if (InputCarBrake != 0)
            {
                this.Brake();
            }

            // falls es eine Kollision gab, wird diese behandelt
            if (CollisionCorner != 0)
            {
                this.HandleCollision();
            }
        }
        #endregion

        /// <summary>
        /// Accelerate wird aufgerufen, wenn der Benutzer Gas gibt
        /// </summary>
        #region Accelerate
        private void Accelerate()
        {
            // neue Geschwindigkeit nach v = a*t berechnen:
            float speed = 0;

            if (InputAcceleration != 0)
            {
                speed = oldSpeed + Math.KMperHour((a(InputAcceleration, maxAcc) * t));
            }

            // Geschwindigkeit prüfen und in Cart schreiben:
            speed = speedCheck(speed);
            pCart.SetSpeed(speed);

            // neue Richtung = alte Richtung da sich nur Speed ändert:
            Vector3 v_direction = new Vector3();
            v_direction = oldDirection;

            // wenn wir fahren, dann:
            if (speed != 0)
            {
                // neue Position ermitteln und schreiben:
                Vector3 v_position = new Vector3();
                v_position = (Math.MeterPerSecond(speed) * v_direction * t) + oldPosition;
                pCart.SetPosition(v_position);
            }
        }
        #endregion

        /// <summary>
        /// Brake wird aufgerufen, wenn der Benutzer bremst.
        /// </summary>
        /// <param name="maxBrake">übergibt maximal negative Beschleunigung</param>
        #region Brake
        private void Brake()
        {
            float speed;

            //Wenn wir schon stehen, dann Funktion verlassen und nichts machen
            if (oldSpeed == 0)
                return;

            // Fahren wir vorwärts oder rückwärts?
            if (oldSpeed > 0)
            {
                maxBrak = maxBrak - 2 * maxBrak;
            }

            // neue Geschwindigkeit berechnen
            speed = oldSpeed + Math.KMperHour((a(InputCarBrake, maxBrak) * t));

            // Falls wir das Vorzeichen der Geschwindigkeit ändern, bleiben wir stehen:
            if ((oldSpeed < 0 && speed > 0)||(oldSpeed > 0 && speed < 0))
            {
                speed = 0;
            }

            pCart.SetSpeed(speed);

            // neue Richtung ermitteln und schreiben:
            Vector3 v_direction = new Vector3();
            v_direction = oldDirection;

            // neue Position ermitteln und schreiben:
            Vector3 v_position = new Vector3();
            v_position = (Math.MeterPerSecond(speed) * v_direction * t) + oldPosition;
            pCart.SetPosition(v_position);
        }
        #endregion

        /// <summary>
        /// noInput wird verwendet, wenn der User nicht beschleunigt.
        /// Es wird nur die Reibung berücksichtigt und die Geschwindigkeit angepasst.
        /// </summary>
        #region noInput
        private void noInput()
        {
            float speed;

            if (oldSpeed == 0)
                return;

            // neue Geschwindigkeit berechnen
            speed = oldSpeed + Math.KMperHour((a(0, 0) * t));
            
            
            // Stehen wir schon oder rollen wie weiter?
            if ((oldSpeed < 0 && speed > 0)||(oldSpeed > 0 && speed < 0))
            {
                // wir stehen!
                speed = 0;
            }
            
            // neue Geschwindigkeit schreiben
                speed = speedCheck(speed);
                pCart.SetSpeed(speed);

            // neue Position ermitteln und schreiben:
            Vector3 v_position = new Vector3();
            Vector3 v_direction = new Vector3();
            v_direction = oldDirection;
            v_position = (Math.MeterPerSecond(speed) * v_direction * t) + oldPosition;
            pCart.SetPosition(v_position);

        }
        #endregion

        /// <summary>
        /// Wird aufgerufen, wenn gelenkt wird
        /// </summary>
        #region Stear
        private void Stear()
        {
            // Winkel um den der Richtungsvektor gedreht wird
            float Angle = 0f;

            // Fahren wir vorwärts oder rückwärts, oder gar nicht?
            if (oldSpeed > 0)
            {
                Angle = InputCarDirection * -0.8f * t;
            }
            else if (oldSpeed < 0)
            {
                Angle = InputCarDirection * 0.8f * t;
            }
            else
            {
                return;
            }

            double x;
            double y;
            float oldx;
            float oldy;
            Vector3 vektor;

            // alter Richtungsvektor auslesen:
            oldx = oldDirection.Z;
            oldy = oldDirection.X;

            // neue Koordinaten berechnen:
            x = oldx * System.Math.Cos(Angle) - oldy * System.Math.Sin(Angle);
            y = oldy * System.Math.Cos(Angle) + oldx * System.Math.Sin(Angle);

            // neue Koordinaten casten:
            oldx = (float) x;
            oldy = (float) y;

            // neuen Vektor schreiben:
            vektor = new Vector3(oldy, 0f, oldx);
            pCart.SetDirection(vektor);
        }
        #endregion

        /// <summary>
        /// Gibt den Einheitsvektor der resultierenden Kraft wieder.  
        /// </summary>
        /// <param name="Acc">Beschleunigung zwischen -1 und 1</param>
        /// <param name="max">maximale Beschleunigung des Autos</param>
        /// <returns>Vektor, der die normalisierte resultierende Kraft enthält</returns>
        #region v_Fres
        private Vector3 v_Fres(float Acc, float max)
        {
            float x;
            float y;
            float z;
            float temp;

            // berechnet die in Y-Richtung wirkende Kraft normiert auf Bereich 0 bis 1
            if (Acc != 0 || oldSpeed != 0)
            {
                temp = Fres_y(Acc, max) / System.Math.Abs(Weight * Acc * max);
            }
            else
            {
                temp = oldDirection.X;
            }

            // Koordinaten des resultierenden Vektors werden ermittelt
            x = temp;
            y = 0;
            z = InputCarDirection;


            // Vektor wird erzeugt und zurückgegeben
            Vector3 vektor = new Vector3(x, y, z);
            
            //Prüfung ob Nullvektor, da Normalisierung sonst nicht möglich!
            if (vektor.X != 0 || vektor.Y != 0 || vektor.Z != 0)
                vektor = Vector3.Normalize(vektor);
            return vektor;
        }
        #endregion

        /// <summary>
        /// Berechnet die Beschleunigung, die auf das Auto wirkt.
        /// </summary>
        /// <param name="Acc">Beschleunigung zwischen -1 und 1</param>
        /// <param name="max">maximale Beschleunigung, die das Auto erzeugen kann</param>
        /// <returns>resultierende Beschleunigung wird ausgegeben</returns>
        #region a
        private float a(float Acc, float max)
        {
            float temp;
            float a;

            temp = Fres_y(Acc, max);
            a = temp / Weight;

            return a;

        }
        #endregion

        /// <summary>
        /// Berechnet den Betrag der resultierenden Beschleunigungskraft.
        /// </summary>
        /// <param name="Acc">nimmt Beschleunigung zwischen -1 und 1 entgegen</param>
        /// <param name="max">maximale mögliche Beschleunigung des Autos</param>
        /// <returns></returns>
        #region Fres_y
        private float Fres_y(float Acc, float max)
        {
            float Friction;
            float Force;
            float temp;

            // Berechnet die Kräfte, die auf das Auto wirken:
            // Beschleunigungskraft:
            Force = Weight * Acc * max;
            
            // Reibunswiderstand:
            Friction = my * Weight * g;

            // Muss die Reibung abgezogen oder addiert werden? 
            // Abhängig von der Fahrtrichtung!
            if (oldSpeed > 0)
            {
                temp = Force - Friction;
            }
            else if (oldSpeed < 0)
            {
                temp = Force + Friction;
            }
            else
            {
                if (max > 0 && Acc > 0)
                {
                    temp = Force - Friction;
                }
                else
                {
                    temp = Force + Friction;
                }
            }

            // gibt resultierende Kraft in N zurück            
            return temp;
        }
        #endregion

        /// <summary>
        /// Prüft, ob die Maximalen Geschwindigkeiten eingehalten werden und setzt die
        /// Werte notfalls auf die Maximalwerte.
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        #region SpeedCheck
        private float speedCheck(float speed)
        {
            // scheller als Maximalgeschwindigkeit Vorwärts?
            if (speed > SpeedMax)
                speed = SpeedMax;
            // schneller als Maximalgeschwindigkeit Rückwärts?
            else if (speed < SpeedMaxRev)
                speed = SpeedMaxRev;
            //Geschwindigkeit zurückgeben
            return speed;
        }
        #endregion

        /// <summary>
        /// HandleCollision wird aufgerufen, wenn eine Collision stattgefunden hat, behandelt
        /// diese und setzt die neuen Werte für Geschwindigkeit und Position
        /// </summary>
        #region HandleCollision
        private void HandleCollision()
        {
            float Rotation;
            float Angle;
            double x;
            double y;
            float oldx;
            float oldy;
            Vector3 vektor;

            // Kollisionen zwischen 60° und 90° führen zu Stillstand des Wagens (Totalschaden)
            // Geschwindigkeit anpassen
            if (CollisionArc < MathHelper.PiOver2 && CollisionArc > MathHelper.Pi / 3.0f)
            {
                pCart.SetSpeed(0.0f);
                Rotation = 0.0f;
            }
            // kleinere Geschwindigkeiten führen zu einer reduzierten Speed und einer Rotation
            else
            {
                pCart.SetSpeed(oldSpeed * 0.7f);
                
                // Rotation bestimmen
                Rotation = CollisionArc * 0.8f * t;
                if (CollisionCorner == Car.FRONTRIGHT || CollisionCorner == Car.BACKLEFT)
                {
                    Rotation = Rotation - 2 * Rotation;
                }

            }
            Angle = Rotation;

            // alter Richtungsvektor auslesen:
            oldx = oldDirection.Z;
            oldy = oldDirection.X;

            // neue Koordinaten berechnen:
            x = oldx * System.Math.Cos(Angle) - oldy * System.Math.Sin(Angle);
            y = oldy * System.Math.Cos(Angle) + oldx * System.Math.Sin(Angle);

            // neue Koordinaten casten:
            oldx = (float)x;
            oldy = (float)y;

            // neuen Vektor schreiben:
            vektor = new Vector3(oldy, 0f, oldx);
            pCart.SetDirection(vektor);
        }
        #endregion
    } 
}
