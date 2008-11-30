// Project: ACT2009, File: Menus.cs
// Namespace: ACT2009, Class: Menus
// Path: \ACT2009\Menus
// Author: Ron Malcolm, Team 2
// Code lines: 225
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
#endregion

namespace ACT2009
{
    class Menus
    {
        #region Variables

        // Textures
        Texture2D menuScreen, menuElements, menuController, menuCredits;

        // Menu Element Rectangles
        static readonly Rectangle
            MenuPlayRect = new Rectangle(0, 24, 360, 72),
            MenuControllerRect = new Rectangle(0, 108, 520, 72),
            MenuCreditsRect = new Rectangle(0, 186, 296, 72),
            MenuExitRect = new Rectangle(0, 264, 200, 72),

            PlayDestRect = new Rectangle(160, 380, 360, 72),
            ControllerDestRect = new Rectangle(160, 422, 520, 72),
            CreditsDestRect = new Rectangle(160, 460, 296, 72),
            ExitDestRect = new Rectangle(160, 498, 200, 72);

        // Menu Colors and Selection
        Color play = Color.White;
        Color controller = Color.White;
        Color credits = Color.White;
        Color exit = Color.White;
        Color game = Color.White;
        Color pauseShadow;
        int selected = 0;

        MenuTabs menuTab = MenuTabs.Play;

        // Menu Tabs Enum
        public enum MenuTabs
        {
            Play,
            Layout,
            Credit,
            Exit
        }

        public Menus()
        {

        }
        #endregion // Variables

        #region MenuInit

        public void MenuInit(ContentManager Content)
        {
            // 2D Assets
            menuScreen = Content.Load<Texture2D>("Textures\\ScreenMenuNav");
            menuElements = Content.Load<Texture2D>("Textures\\ScreenMenuNavElements");
            menuController = Content.Load<Texture2D>("Textures\\ScreenController");
            menuCredits = Content.Load<Texture2D>("Textures\\ScreenCredits");
        }
        #endregion // Initialize

        #region MenuUpdate

        bool menuUp = false;
        bool menuDown = false;

        public Game1.GameMode MenuUpdate(GameTime gameTime, Game1.GameMode gameMode)
        {
            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);

            // Menu Nav Boundaries
            if (gameMode == Game1.GameMode.Main)
            {

                if ((keyboard.IsKeyDown(Keys.Up) || gamePad.DPad.Up == ButtonState.Pressed) && menuUp)
                {
                    menuUp = false;
                    if (selected == 0)
                        selected = 3;
                    else
                        selected--;
                    Sounds.PlayBangSound();
                }
                else if ((keyboard.IsKeyUp(Keys.Up) && gamePad.DPad.Up == ButtonState.Released))
                    menuUp = true;
                if ((keyboard.IsKeyDown(Keys.Down) || gamePad.DPad.Down == ButtonState.Pressed) && menuDown)
                {
                    menuDown = false;
                    if (selected == 3)
                        selected = 0;
                    else
                        selected++;
                    Sounds.PlayBangSound();
                }
                else if (keyboard.IsKeyUp(Keys.Down) && gamePad.DPad.Down == ButtonState.Released)
                    menuDown = true;

                // Menu Tab Colors and Tab State
                if (selected == 0)
                {
                    menuTab = MenuTabs.Play;
                    play = Color.Blue;
                    controller = Color.White;
                    exit = Color.White;
                }
                else if (selected == 1)
                {
                    menuTab = MenuTabs.Layout;
                    play = Color.White;
                    controller = Color.Blue;
                    credits = Color.White;
                }
                else if (selected == 2)
                {
                    menuTab = MenuTabs.Credit;
                    controller = Color.White;
                    credits = Color.Blue;
                    exit = Color.White;
                }
                else if (selected == 3)
                {
                    menuTab = MenuTabs.Exit;
                    play = Color.White;
                    credits = Color.White;
                    exit = Color.Blue;
                }
            } // GameMode Main

            // Tab Control
            // Play Game
            if (menuTab == MenuTabs.Play && keyboard.IsKeyDown(Keys.Enter) ||
                gamePad.Buttons.A == ButtonState.Pressed)
            {
                gameMode = Game1.GameMode.Play;
                Sounds.PlayBrakesSound();
            }
            // Go To Controller Layout
            if (menuTab == MenuTabs.Layout && keyboard.IsKeyDown(Keys.Enter) ||
                gamePad.Buttons.A == ButtonState.Pressed)
                gameMode = Game1.GameMode.Controller;
            // Go To Credits
            if (menuTab == MenuTabs.Credit && keyboard.IsKeyDown(Keys.Enter) ||
                gamePad.Buttons.A == ButtonState.Pressed)
                gameMode = Game1.GameMode.Credits;
            // Return To Main
            if (gameMode == Game1.GameMode.Controller && keyboard.IsKeyDown(Keys.Escape) ||
                gamePad.Buttons.Back == ButtonState.Pressed)
                gameMode = Game1.GameMode.Main;
            if (gameMode == Game1.GameMode.Credits && keyboard.IsKeyDown(Keys.Escape) ||
                gamePad.Buttons.Back == ButtonState.Pressed)
                gameMode = Game1.GameMode.Main;
            if (gameMode == Game1.GameMode.Play && keyboard.IsKeyDown(Keys.Escape) ||
                gamePad.Buttons.Back == ButtonState.Pressed)
                gameMode = Game1.GameMode.Main;
            // Exit Game
            if (menuTab == MenuTabs.Exit && keyboard.IsKeyDown(Keys.Enter) ||
                gamePad.Buttons.Back == ButtonState.Pressed)
                gameMode = Game1.GameMode.Exit;
            
            return gameMode;
        }
        #endregion // Update

        #region MenuDraw

        public void MenuDraw(SpriteBatch spriteBatch, Game1.GameMode gameMode)
        {
            // Draw Menu            
            spriteBatch.Begin();
            {
                if (gameMode == Game1.GameMode.Main)
                {
                    spriteBatch.Draw(menuScreen, Vector2.Zero, Color.White);
                    spriteBatch.Draw(menuElements, PlayDestRect, MenuPlayRect, play);
                    spriteBatch.Draw(menuElements, ControllerDestRect, MenuControllerRect, controller);
                    spriteBatch.Draw(menuElements, CreditsDestRect, MenuCreditsRect, credits);
                    spriteBatch.Draw(menuElements, ExitDestRect, MenuExitRect, exit);
                }
                else if (gameMode == Game1.GameMode.Controller)
                    spriteBatch.Draw(menuController, Vector2.Zero, Color.White);
                else if (gameMode == Game1.GameMode.Credits)
                    spriteBatch.Draw(menuCredits, Vector2.Zero, Color.White);
            }
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(menuController, Vector2.Zero, Color.White);
            spriteBatch.End();
        }
        #endregion // Draw

    }
}
