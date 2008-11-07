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

namespace Working_Speedometer
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        Texture2D HUD2Texture;
        Rectangle viewportRect;
        SpriteBatch spriteBatch;
        GameObject needle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Load your graphics content
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            HUD2Texture =
                   Content.Load<Texture2D>("Sprites\\HUD2");

            needle = new GameObject(Content.Load<Texture2D>("Sprites\\needle"));
            needle.position = new Vector2(661, graphics.GraphicsDevice.Viewport.Height - 89);
            //Create a Rectangle that represents the full
            //drawable area of the game screen.
            viewportRect = new Rectangle(0, 0,
                graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height);

            base.LoadContent();
        }


        /// <summary>
        /// Unload any content not managed by the Content Manager
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            needle.rotation += gamePadState.ThumbSticks.Left.X * 0.1f;
#if !XBOX
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                needle.rotation -= 0.01f;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                needle.rotation += 0.01f;
            }
#endif
            needle.rotation = MathHelper.Clamp(needle.rotation, -MathHelper.PiOver2, 1);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            //Draw the HUD2Texture sized to the width
            //and height of the screen.
            spriteBatch.Draw(HUD2Texture, viewportRect,
                Color.White);
            spriteBatch.Draw(needle.sprite,
                needle.position,
                null,
                Color.White,
                needle.rotation,
                needle.center, 1.0f,
                SpriteEffects.None, 0);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
