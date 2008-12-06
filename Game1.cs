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
using System.Globalization;
using Microsoft.Xna.Framework.Media;
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
        Play play;

        //Jasmin
        Sounds Sounds;

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
            Input input = new Input();
            actCart = new Car(ref input);
            actCart.SetPosition(new Vector3(3, 0, 120));
            actCart.SetDirection(new Vector3(1.0f, 0, 0.0f));
            physics = new Physics(ref actCart);
            Sounds = new Sounds(this);

            base.Initialize();
        }

        /// <summary>
        /// Loads the points for elementpositioning from an xml file
        /// </summary>
        private List<Vector3> loadPoints(String xmlFile)
        {
            List<Vector3> trackPoints = new List<Vector3>();

            String xmlData = Content.Load<string>(xmlFile);
            xmlData = xmlData.Trim();
            String[] lines = xmlData.Split('\n');

            // Gets a NumberFormatInfo associated with the en-US culture.
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            for (int i = 0; i < lines.Length; i++)
            {
                String[] currLineCoords = lines[i].Split(' ');
                trackPoints.Add(new Vector3(float.Parse(currLineCoords[0], nfi),
                                                float.Parse(currLineCoords[2], nfi),
                                                float.Parse(currLineCoords[1], nfi)));
            }

            return trackPoints;
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
            display.DisplayInit(Content, graphics.GraphicsDevice, ref actCart);

            // 3D Assets
            /*genCart = Content.Load<Model>("Models\\Generic Cart");
            aspectRatio = (float)graphics.GraphicsDevice.Viewport.Width / (float)graphics.GraphicsDevice.Viewport.Height;
            */
            //// TODO: use this.Content to load your game content here

            //Sounds
            //Song mysong = Content.Load<Song>("Sounds\\menumusic");
            
            Sounds.PlayMenuMusicSound(true);

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

            // Sound Call Test
            
            // Menu Update
            gameMode = menu.MenuUpdate(gameTime, gameMode);

            //Updating the car, which calls its corresponding input-update
            actCart.Update();

            //Rotate the car  
            if(actCart.GetController().GetDirection() < 0)
            {
                Vector3 tempVector = actCart.GetDirection();
                tempVector.Normalize();
                actCart.SetDirection(tempVector);

                double angle = System.Math.Atan2(actCart.GetDirection().Z, actCart.GetDirection().X) -0.03;
                actCart.SetDirection(new Vector3((float)System.Math.Cos(angle), 0.0f, (float)System.Math.Sin(angle)));
            }
            else if (actCart.GetController().GetDirection() > 0)
            {
                Vector3 tempVector = actCart.GetDirection();
                tempVector.Normalize();
                actCart.SetDirection(tempVector);

                double angle = System.Math.Atan2(actCart.GetDirection().Z, actCart.GetDirection().X) + 0.03;
                actCart.SetDirection(new Vector3((float)System.Math.Cos(angle), 0.0f, (float)System.Math.Sin(angle)));
            }

            //Change Car Position
            if (actCart.GetController().GetAccelleration() > 0)
            {
                float speedFactor = 0.2f;
                actCart.SetPosition(actCart.GetPosition() + new Vector3((float)actCart.GetDirection().X * speedFactor, (float)actCart.GetDirection().Y * speedFactor, (float)actCart.GetDirection().Z * speedFactor));
            }

            // Updating the game physic
            physics.Update(gameTime);

            // Updating the Display (only neccesery for debugging help.)
            display.Update(keyboard);
            play.PlayUpdate(gameTime, gameMode);
            
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
