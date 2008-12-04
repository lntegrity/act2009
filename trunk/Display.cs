using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ACT2009
{
    class Display
    {
        // 3D stuff
        private Model car, landscape;
        //Matrix worldMatrix;
        //Matrix RotationMatrix;

        // The graphic device for some 3D methods
        private GraphicsDevice device;

        private Matrix viewMatrix;
        private Matrix projectionMatrix;

        // Debugging helper
        // Those variables are used to navigate throught the landscape
        // Not a part of the gameplay
        private bool navigationHelper = false; // navigation debugging helper ON OFF?
        private Matrix navPositionMatrix; // navigation position
        private float Xrot, Yrot; // navigation direction
        private float movingSpeed = 1.0f; // moving speed when navigating
        private bool NBpushed = false; // N + B key pushed?


        float carScaleValue = 0.015f; // Car Size

        //Vector3 carPosition;
        Vector3 carOffset, carRotationOffset;
        Car actCart;

        public void DisplayInit(ContentManager Content, GraphicsDevice dev, ref Car carObj)
        {
            // Loading the 3D models
            car = Content.Load<Model>("Models/Generic Cart");
            landscape = Content.Load<Model>("Models/fhhof");

            device = dev;

            actCart = carObj;
            //carPosition = new Vector3(45.0f, 0.0f, 70.0f);
            carOffset = new Vector3(0.0f, -0.20f, 2.5f);
            carRotationOffset = new Vector3(0.4f, 0.0f, 0.5f);

            Yrot = 3.141592f; // base 180° rotation
            navPositionMatrix = Matrix.CreateTranslation(new Vector3(0.0f, -1.0f, 0.0f));
            viewMatrix = Matrix.CreateLookAt(new Vector3(0, 2, 5), Vector3.Zero, Vector3.Up);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), 800.0f / 600.0f, 1.0f, 1000.0f);
        
        }

        // Rotated Translation matrix = move into the direction your looking at.
        public Matrix rotatedTranslation(Matrix tMatrix)
        {
            return Matrix.CreateRotationY(Yrot) * Matrix.CreateRotationX(Xrot) * tMatrix * Matrix.CreateRotationX(-Xrot) * Matrix.CreateRotationY(-Yrot);
        }

        // Debbuging helper navigation
        public void Update(KeyboardState keyboardState)
        {
            // switching debugging navigation helper ON OFF
            if (keyboardState.IsKeyDown(Keys.N) && keyboardState.IsKeyDown(Keys.B))
            {
                if (!NBpushed)
                {
                    NBpushed = true;
                    if (navigationHelper)
                    {
                        navigationHelper = false;
                        // Set the cam position back behind the car
                        navPositionMatrix = Matrix.CreateTranslation(new Vector3(0.0f, -1.0f, 0.0f));
                        Yrot = 3.14f;
                        Xrot = 0.0f;
                    }
                    else
                    {
                        navigationHelper = true;
                    }
                }
            }
            else
            {
                NBpushed = false;
            }


            // Checking for key inputs -> Navigation
            if (navigationHelper)
            {
                if (keyboardState.IsKeyDown(Keys.A))
                    navPositionMatrix *= rotatedTranslation(Matrix.CreateTranslation(new Vector3(movingSpeed, 0.0f, 0.0f)));
                else if (keyboardState.IsKeyDown(Keys.D))
                    navPositionMatrix *= rotatedTranslation(Matrix.CreateTranslation(new Vector3(-movingSpeed, 0.0f, 0.0f)));

                if (keyboardState.IsKeyDown(Keys.W))
                    navPositionMatrix *= rotatedTranslation(Matrix.CreateTranslation(new Vector3(0.0f, 0.0f, movingSpeed)));
                else if (keyboardState.IsKeyDown(Keys.S))
                    navPositionMatrix *= rotatedTranslation(Matrix.CreateTranslation(new Vector3(0.0f, 0.0f, -movingSpeed)));

                if (keyboardState.IsKeyDown(Keys.Left))
                    Yrot -= 0.03f;
                else if (keyboardState.IsKeyDown(Keys.Right))
                    Yrot += 0.03f;

                if (keyboardState.IsKeyDown(Keys.Up))
                    Xrot -= 0.03f;
                else if (keyboardState.IsKeyDown(Keys.Down))
                    Xrot += 0.03f;
            }
        }

        // The method for called for drawing the 3D environment
        public void Draw()
        {
            // Graphic Device settings
            device.RenderState.DepthBufferEnable = true;
            device.RenderState.AlphaBlendEnable = true;

            // car bones for car parts position
            Matrix[] transforms = new Matrix[car.Bones.Count];
            car.CopyAbsoluteBoneTransformsTo(transforms);

            Vector3 tempVector = actCart.GetDirection();
            tempVector.Normalize();
            actCart.SetDirection(tempVector);

            // Draw the landscape
            foreach (ModelMesh mesh in landscape.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    // Position of the landscape on the screen
                    effect.World =  Matrix.CreateTranslation(actCart.GetPosition()) // translate the landscape based on car position
                                    * navPositionMatrix                 // debbuging navigation helper position
                                    * Matrix.CreateRotationY((float)(System.Math.PI/2))
                                    * Matrix.CreateTranslation(new Vector3(-carOffset.X, -carOffset.Y, -carOffset.Z))
                                    * Matrix.CreateTranslation(new Vector3(-carRotationOffset.X, -carRotationOffset.Y, -carRotationOffset.Z))
                                    * Matrix.CreateRotationY((float)(System.Math.Atan2(actCart.GetDirection().Z, actCart.GetDirection().X)))
                                    * Matrix.CreateTranslation(carOffset)
                                    * Matrix.CreateTranslation(carRotationOffset)
                                    * Matrix.CreateRotationY(Yrot)      // debbuging navigation helper rotation
                                    * Matrix.CreateRotationX(Xrot);     // debbuging navigation helper rotation

                    effect.View = viewMatrix;

                    effect.Projection = projectionMatrix;
                }
                mesh.Draw();
            }


            // Draw the car
            foreach (ModelMesh mesh in car.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    // Position of the car on the screen
                    effect.World =  transforms[mesh.ParentBone.Index]   // Positions of the car parts based on the bones
                                    * Matrix.CreateScale(carScaleValue) // scaling the car size
                                    * Matrix.CreateTranslation(carOffset) // car screen position offset
                                    * Matrix.CreateTranslation(carRotationOffset)
                                    * navPositionMatrix                 // debbuging navigation helper position
                                    * Matrix.CreateRotationY(Yrot)      // debbuging navigation helper rotation
                                    * Matrix.CreateRotationX(Xrot);     // debbuging navigation helper rotation

                    effect.View = viewMatrix;

                    effect.Projection = projectionMatrix;
                }
                mesh.Draw();
            }
        }
    }
}
