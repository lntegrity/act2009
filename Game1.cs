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
    /// The core-class of the ACT2009 Project
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

        //Collisiondetection
        Collisiondetect collision;

        // Object Coordinates
        ModelPositions innerBorder;
        ModelPositions outerBorder;
        ModelPositions trees;
        ModelPositions carFord;
        ModelPositions carGolf;
        ModelPositions bushes;

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
        GameMode previousMenu;

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
            
            //TODO: fix
            Model spike = Content.Load<Model>("Models/huetchen");
            Model carNPC = Content.Load<Model>("Models/_obstacleCar");
            Model tree = Content.Load<Model>("Models/tree");
            Model hedge = Content.Load<Model>("Models/hecken_tree");


            Vector3 innerOffsets = new Vector3(0f, 0.1f, 0f);
            Vector3 outerOffsets = new Vector3(0f, 0.1f, 0f);
            Vector3 treesOffsets = new Vector3(0f, 0.0f, 0f);
            Vector3 bushesOffsets = new Vector3(0f, -0.3f, 0f);
            Vector3 carFordOffsets = new Vector3(-1.0f, 0.65f, 1.5f);
            Vector3 carGolfOffsets = new Vector3(0f, 0.35f, -1.5f);

            List<Vector3> innerCoord = loadPoints("coordinate/innerBorder", innerOffsets);
            List<Vector3> outerCoord = loadPoints("coordinate/outerBorder", outerOffsets);
            List<Vector3> treesCoord = loadPoints("coordinate/tree", treesOffsets);
            List<Vector3> bushesCoord = loadPoints("coordinate/hedge", bushesOffsets);
            List<Vector3> carFordCoord = loadPoints("coordinate/carFord", carFordOffsets);
            List<Vector3> carGolfCoord = loadPoints("coordinate/carGolf", carGolfOffsets);

            innerBorder = new ModelPositions(spike, innerCoord);
            outerBorder = new ModelPositions(spike, outerCoord);
            trees = new ModelPositions(tree, treesCoord);
            bushes = new ModelPositions(hedge, bushesCoord);
            carFord = new ModelPositions(carNPC, carFordCoord);
            carGolf = new ModelPositions(carNPC, carGolfCoord);
            carFord.setScale(0.03f);
            carGolf.setScale(0.03f);

            collision = new Collisiondetect(actCart, innerBorder, outerBorder);
            
            menu.MenuInit(Content);
            play.PlayInit(Content);
            display.DisplayInit(Content, graphics.GraphicsDevice, ref actCart);

            Sounds.PlayMenuMusicSound(true);

        }

        /// <summary>
        /// Loads the points for elementpositioning from an xml file
        /// </summary>
        private List<Vector3> loadPoints(String xmlFile, Vector3 offsets)
        {
            List<Vector3> trackPoints = new List<Vector3>();
            
            String xmlData = Content.Load<String>(xmlFile);
            xmlData = xmlData.Trim();
            //char[] tempArr = new char[] { '\n', '\r' };
            String[] lines = xmlData.Split('\n');

            // Gets a NumberFormatInfo associated with the en-US culture.
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            for (int i = 0; i < lines.Length; i++)
            {
                String[] currLineCoords = lines[i].Split(';');
                trackPoints.Add(new Vector3(float.Parse(currLineCoords[0], nfi) + offsets.X,
                                                float.Parse(currLineCoords[1], nfi) + offsets.Y,
                                                -float.Parse(currLineCoords[2], nfi) + offsets.Z));
            }

            return trackPoints;
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
            //Console.WriteLine("Game1.cs:Update()");
            // Game Music Change
            // Menu Update
            previousMenu = gameMode;
            gameMode = menu.MenuUpdate(gameTime, gameMode);
            //Console.WriteLine("GameMode: " + gameMode + "PreviousMenu: " + previousMenu);

            //So we are in the main menu after the game
            if (previousMenu == GameMode.Play && gameMode != previousMenu)
            {
                //Console.WriteLine("Previous Menu: Play");
                Sounds.quitAllSEI(); // quits all currently running SoundEffects
                Sounds.StopMusic();
                Sounds.PlayMenuMusicSound(true);
            }
            else if (gameMode == GameMode.Play && gameMode != previousMenu)
            {
                //Console.WriteLine("gameMode:Play, previousMenu:Main");
                Sounds.StopMusic();
                Sounds.PlayGameMusic(true);
                Sounds.PlayFinalDriveSound(1,true);
            }
            else if (gameMode == GameMode.Main && previousMenu == GameMode.Play)
            {
                //Console.WriteLine("gameMode:Main, previousMenu:Play");
                //Sounds.getSoundEffectInstance().Stop();
                Sounds.StopMusic();

                //Sounds.PlayMenuMusicSound(true);
                Sounds.quitAllSEI(); // quits all currently running SoundEffects
            }
            
            /*if (gameMode != previousMenu)
            {
                Sounds.PlayHornSound(false);
            }*/

            // Allows the game to exit
            if (gameMode == GameMode.Exit && ((keyboard.IsKeyDown(Keys.Enter) ||
                gamePad.Buttons.A == ButtonState.Pressed)))
            {
                this.Exit();
                //Console.Write("Exit Game");
            }

            Sounds.Update();

            //Updating the car, which calls its corresponding input-update
            actCart.Update();

            // Updating the game physic
            physics.Update(gameTime);

            // Updating the Display (only neccesery for debugging help.)
            display.Update(keyboard);
            play.PlayUpdate(gameTime, gameMode, ref actCart);
            
            //if (gameMode == GameMode.Play && keyboard.IsKeyDown(Keys.Escape))
            //{
            //    gameMode = GameMode.Pause;
            //    this.game = this.pauseShadow;
            //}

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

                display.DrawBackground(spriteBatch);

                graphics.GraphicsDevice.RenderState.DepthBufferEnable = true;
                display.Draw();

                // Draw Objects on the Landscape
                innerBorder.DrawObjects(display);
                outerBorder.DrawObjects(display);
                carFord.DrawObjects(display);
                carGolf.DrawObjects(display);
                trees.DrawObjects(display);
                bushes.DrawObjects(display);

                play.PlayDraw(spriteBatch);                
                
                // foreach Mesh
            } // if GameMode Play

            base.Draw(gameTime);
        }
        #endregion // Draw
    }
}
