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
    class Play
    {
        #region Variables

        // Textures
        Texture2D hudNeedle, hudMeter, hudMap;
        Model genCart;

        // Menu Element Rectangles
        static readonly Rectangle
            hudNeedleDest = new Rectangle(0, 24, 360, 72);

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
           
            // 3D Assets
            genCart = Content.Load<Model>("Models\\Generic Cart");
        }
        #endregion // Initialize

        #region PlayUpdate

        public Game1.GameMode PlayUpdate(GameTime gameTime, Game1.GameMode gameMode)
        {
            // Update Play Method    
        }
        #endregion

    }
}
