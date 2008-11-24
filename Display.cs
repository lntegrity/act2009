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
        Model car, landscape;
        //Matrix worldMatrix;
        //Matrix RotationMatrix;

        Matrix PositionMatrix;
        Matrix viewMatrix;
        Matrix projectionMatrix;
        float Xrot, Yrot;
        float movingSpeed = 0.5f;
        float rotationSpeed = 0.03f;

        float carScaleValue = 0.01f;

        Vector3 carPosition, carOffset;


        public Display()
        {
        }

        public void DisplayInit(ContentManager Content)
        {
            // test-Model
            car = Content.Load<Model>("Models/Generic Cart");
            landscape = Content.Load<Model>("Models/complete_smooth_track2");

            carPosition = new Vector3(45.0f, 0.0f, 70.0f);
            carOffset = new Vector3(0.1f, 0.0f, 3.0f);

            Yrot = 3.14f;
            PositionMatrix = Matrix.CreateTranslation(new Vector3(0.0f, -1.0f, 0.0f));
            viewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 1), Vector3.Zero, Vector3.Up);
            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), 800.0f / 600.0f, 1.0f, 10000.0f);
        
        }

        // Rotated Translation matrix = move into the direction your looking at.
        public Matrix rotatedTranslation(Matrix tMatrix)
        {
            return Matrix.CreateRotationY(Yrot) * Matrix.CreateRotationX(Xrot) * tMatrix * Matrix.CreateRotationX(-Xrot) * Matrix.CreateRotationY(-Yrot);
        }

        public void Update(KeyboardState keyboardState)
        {
            // Checking for key inputs -> Navigation
            if (keyboardState.IsKeyDown(Keys.A))
                PositionMatrix *= rotatedTranslation(Matrix.CreateTranslation(new Vector3(movingSpeed, 0.0f, 0.0f)));
            else if (keyboardState.IsKeyDown(Keys.D))
                PositionMatrix *= rotatedTranslation(Matrix.CreateTranslation(new Vector3(-movingSpeed, 0.0f, 0.0f)));

            if (keyboardState.IsKeyDown(Keys.W))
                PositionMatrix *= rotatedTranslation(Matrix.CreateTranslation(new Vector3(0.0f, 0.0f, movingSpeed)));
            else if (keyboardState.IsKeyDown(Keys.S))
                PositionMatrix *= rotatedTranslation(Matrix.CreateTranslation(new Vector3(0.0f, 0.0f, -movingSpeed)));

            if (keyboardState.IsKeyDown(Keys.Left))
                Yrot -= 0.03f;
            else if (keyboardState.IsKeyDown(Keys.Right))
                Yrot += 0.03f;

            if (keyboardState.IsKeyDown(Keys.Up))
                Xrot -= 0.03f;
            else if (keyboardState.IsKeyDown(Keys.Down))
                Xrot += 0.03f;
        }

        public void Draw()
        {
            Matrix[] transforms = new Matrix[car.Bones.Count];
            car.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in car.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateScale(carScaleValue) * PositionMatrix *Matrix.CreateTranslation(carOffset) * Matrix.CreateRotationY(Yrot) * Matrix.CreateRotationX(Xrot);
                    effect.View = viewMatrix;

                    effect.Projection = projectionMatrix;
                }
                mesh.Draw();
            }

            foreach (ModelMesh mesh in landscape.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = PositionMatrix * Matrix.CreateTranslation(carPosition) * Matrix.CreateRotationY(Yrot) * Matrix.CreateRotationX(Xrot);
                    effect.View = viewMatrix;

                    effect.Projection = projectionMatrix;
                }
                mesh.Draw();
            }
        }
    }
}
