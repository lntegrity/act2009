// Project: ACT2009, File: Play.cs
// Namespace: ACT2009, Class: Play
// Path: \ACT2009\Play
// Author: Ron Malcolm, Team 2
// Code lines: 225
// Creation date: 11.05.2008 10:55
// Last modified: 11.05.2008 13:15

#region Using Directives
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using System.IO;
#endregion

namespace ACT2009
{

    /// <summary>
    /// This class displays the heads up display
    /// </summary>
    public class Play
    {
        #region Variables

        // Textures
        Texture2D hudMeter, hudNeedle;
        Model genCart;

        // Menu Element Rectangles
        static readonly Rectangle
            hudNeedleDest = new Rectangle(690, 570, 180, 140),
            hudMeterDest = new Rectangle(600, 500, 180, 140);

        // Needle Variables
        float rotation;
        Vector2 center;
                
        public Play()
        {

        }
        #endregion // Variables

        #region PlayInit

        public void PlayInit(ContentManager Content)
        {
            // 2D Assets
            hudMeter = Content.Load<Texture2D>("Textures\\SpeedometerImage");
            hudNeedle = Content.Load<Texture2D>("Textures\\needle");

            center = new Vector2(hudNeedle.Width / 2, hudNeedle.Height / 2);
   
            // 3D Assets
            genCart = Content.Load<Model>("Models\\Generic Cart");

            rotation = -5.0f;
        }
        #endregion // Initialize

        #region PlayUpdate

        public Game1.GameMode PlayUpdate(GameTime gameTime, Game1.GameMode gameMode, ref Car cart)
        {
            // Update Play Method
            KeyboardState keyboard = Keyboard.GetState();
    
            float speed;
            speed = cart.GetSpeed();

            speed = (speed * 2.9708f) / 90f;

            rotation = speed - MathHelper.PiOver2;
            rotation = MathHelper.Clamp(rotation, -MathHelper.PiOver2, 1.4f);
            
            return gameMode;
        }
        #endregion

        #region PlayDraw

        public void PlayDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(hudMeter, hudMeterDest, Color.White);
            spriteBatch.Draw(hudNeedle,
                hudNeedleDest,
                null,
                Color.White,
                rotation,
                center,
                SpriteEffects.None, 0);
            spriteBatch.End();
        }
        #endregion
    }
}
