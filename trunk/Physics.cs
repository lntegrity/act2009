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
    { 
        // Definiert Hilfsvariablen, die dann im Konstruktor gefüllt werden und zur
        // Verwendung in der Klasse bereitgestellt werden.
        private Input input;

        // stellt Variablen für Werte der Inputklasse bereit
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

        //stellt weitere Variablen und Constanten bereit:
        private const float g = 9.81f;
        private const float my = 0.45f;
        private Car pCart;
        private float t;
        private float oldt;
        
        public Physics(ref Car cart)
        {
            // lädt alle wichtigen Parameter in die Variablen
            pCart=cart;
            input = pCart.GetController();
        }

        /// <summary>
        /// Update wird aufgerufen um auf die Eingaben aus der Inputklasse zu reagieren und die
        /// entsprechende interne Funktionalität aufzurufen. 
        /// </summary>
        public void Update(GameTime gtime)
        {

            InputAcceleration = input.GetAccelleration();
            //InputAcceleration = 1f;
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
            
            //Aktuelle Zeit wird berechnet
            //if (oldt == 0f)
            //{
            //    oldt = gtime.TotalGameTime.Seconds;
            //}

            t = (float) gtime.ElapsedGameTime.Milliseconds/1000f;
            oldt = gtime.TotalGameTime.Milliseconds/1000f;
            // wird gebremst, dann Brake-Funktion starten
            
            if (InputCarBrake != 0)
                this.Brake();
            // wird nicht gelenkt, dann noInput aufrufen
            if (InputCarDirection == 0 && InputAcceleration == 0 && InputCarBrake == 0)
                this.noInput();
            // wird gelenkt oder Gas gegeben, dann Accelerate aufrufen
            else
                this.Accelerate();
        }
        
        /// <summary>
        /// Wird aufgerufen, wenn der Benutzer Gas gibt und/oder lenkt
        /// </summary>
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

            // neue Richtung ermitteln und schreiben:
            Vector3 v_direction = new Vector3();
            if (InputCarDirection != 0)
            {              
                v_direction = oldDirection + v_Fres(InputAcceleration, maxAcc);
                v_direction = Vector3.Normalize(v_direction);
                pCart.SetDirection(v_direction);
            }
            else
            {
                v_direction = oldDirection;
            }

            if (speed != 0)
            {
                // neue Position ermitteln und schreiben:
                Vector3 v_position = new Vector3();
                v_position = (Math.MeterPerSecond(speed) * v_direction * t) + oldPosition;
                pCart.SetPosition(v_position);
            }
        }

        /// <summary>
        /// Wird aufgerufen, wenn der Benutzer bremst.
        /// </summary>
        /// <param name="maxBrake">übergibt maximal negative Beschleunigung</param>
        
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

        /// <summary>
        /// Wird verwendet, wenn der User weder beschleunigt, bremst noch lenkt.
        /// Es wird nur die Reibung berücksichtigt und die Geschwindigkeit angepasst.
        /// </summary>
        
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
        /// <summary>
        /// Gibt den Einheitsvektor der resultierenden Kraft wieder.  
        /// </summary>
        /// <param name="Acc">Beschleunigung zwischen -1 und 1</param>
        /// <param name="max">maximale Beschleunigung des Autos</param>
        /// <returns>Vektor, der die normalisierte resultierende Kraft enthält</returns>
        private Vector3 v_Fres(float Acc, float max)
        {
            float x;
            float y;
            float z;
            float temp;

            // berechnet die in Y-Richtung wirkende Kraft normiert auf Bereich 0 bis 1
            if (Acc != 0)
            {
                temp = Fres_y(Acc, max) / System.Math.Abs(Weight * Acc * max);
            }
            else
            {
                temp = 0;
            }

            // Koordinaten des resultierenden Vektors werden ermittelt
            x = InputCarDirection;
            y = 0;
            z = temp;

            // Vektor wird erzeugt und zurückgegeben
            Vector3 vektor = new Vector3(x, y, z);
            
            //Prüfung ob Nullvektor, da Normalisierung sonst nicht möglich!
            if (vektor.X != 0 || vektor.Y != 0 || vektor.Z != 0)
                vektor = Vector3.Normalize(vektor);
            return vektor;
         }

        /// <summary>
        /// Berechnet die Beschleunigung, die auf das Auto wirkt.
        /// </summary>
        /// <param name="Acc">Beschleunigung zwischen -1 und 1</param>
        /// <param name="max">maximale Beschleunigung, die das Auto erzeugen kann</param>
        /// <returns>resultierende Beschleunigung wird ausgegeben</returns>
        private float a(float Acc, float max)
        {
            float temp;
            float a;

            temp = Fres_y(Acc, max);
            a = temp / Weight;

            return a;

        }

        /// <summary>
        /// Berechnet den Betrag der resultierenden Beschleunigungskraft.
        /// </summary>
        /// <param name="Acc">nimmt Beschleunigung zwischen -1 und 1 entgegen</param>
        /// <param name="max">maximale mögliche Beschleunigung des Autos</param>
        /// <returns></returns>
        private float Fres_y(float Acc, float max)
        {
            float Friction;
            float Result;
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

        /// <summary>
        /// Prüft, ob die Maximalen Geschwindigkeiten eingehalten werden und setzt die
        /// Werte notfalls auf die Maximalwerte.
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
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

        public void Test()
        {
            //a(-1f, 10f);
            //v_Fres(-1f, 6.9f);
            //noInput();
            //Brake(8.0f);
            //Accelerate();
        }
    
    } 
}
