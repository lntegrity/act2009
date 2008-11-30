// Project: ACT2009, File: Game1.cs
// Namespace: ACT2009, Class: Game1
// Path: \ACT2009\Game1
// Author: Ron Malcolm, Team 2
// Code lines: 222
// Creation date: 10.21.2008 09:55
// Last modified: 10.31.2008 13:15

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
using System.Text;
using System.Threading;
#endregion

namespace ACT2009
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Variables

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // the Display object -> controlls the Display of the game.
        Display display;
        //Car object, contains car-related information
        Car actCart;
        //Physics for turning, accdellerating and braking the car
        Physics physics;

        // Input Objects
        KeyboardState keyboard = Keyboard.GetState();
        GamePadState gamePad = GamePad.GetState(PlayerIndex.One);


        // Menu Enum
        public enum GameMode
        {
            Play,
            Pause,
            Main,
            Controller,
            Credits,
            Exit
        }
        GameMode gameMode = GameMode.Main;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            //pauseShadow = new Color(128, 128, 128, 128);
        }

        Menus menu;
        Play play;

        #endregion  // Variables

        #region Initialize
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            menu = new Menus();
            play = new Play();
            display = new Display();
            actCart = new Car(new Input());
            physics = new Physics(ref actCart);
            
            base.Initialize();
        }
        
        #endregion // Initialize
        
        #region Load Content
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menu.MenuInit(Content);
            play.PlayInit(Content);
            display.DisplayInit(Content, graphics.GraphicsDevice, actCart);

            // 3D Assets
            /*genCart = Content.Load<Model>("Models\\Generic Cart");
            aspectRatio = (float)graphics.GraphicsDevice.Viewport.Width / (float)graphics.GraphicsDevice.Viewport.Height;
            */
            //// TODO: use this.Content to load your game content here
        }
        
        #endregion // Load Content

        #region Unload Content
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        #endregion

        #region Update
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

       
        Vector3 modelPos = new Vector3(30.0f, -100.0f, 50.0f);

        protected override void Update(GameTime gameTime)
        {            
            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            
            // Sound Update
            Sounds.Update();
            
            // Menu Update
            gameMode = menu.MenuUpdate(gameTime, gameMode);

            //Updating the car, which calls its corresponding input-update
            actCart.Update();

            // Updating the game physic
            physics.Update(gameTime);

            // Updating the Display (only neccesery for debugging help.)
            display.Update(keyboard);
            
            //if (gameMode == GameMode.Play && keyboard.IsKeyDown(Keys.Escape))
            //{
            //    gameMode = GameMode.Pause;
            //    this.game = this.pauseShadow;
            //}

            // Allows the game to exit
            if (gameMode == GameMode.Exit && ((keyboard.IsKeyDown(Keys.Enter) ||
                gamePad.Buttons.A == ButtonState.Pressed)))
            {
                this.Exit();
                Console.Write("Exit Game");
            }

            base.Update(gameTime);
        }

        #endregion // Update

        #region Draw
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        // 3D Assists
        Vector3 cameraPos = new Vector3(0.0f, 0.0f, 500.0f);
        //Model genCart;

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            
            // Call Menu and Game state Draw methods here
            menu.MenuDraw(spriteBatch, gameMode);

            // Draw Golf Cart and HUD in GameMode.Play
            if (gameMode == GameMode.Play)
            {
                
                

                graphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
                display.Draw();
                play.PlayDraw(spriteBatch);                
                
                // foreach Mesh
            } // if GameMode Play

            base.Draw(gameTime);
        }
        #endregion // Draw
    }
}
