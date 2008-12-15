using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ACT2009
{
    /// <summary>
    /// This class is a container for a list of positions and its corresponding Model that shall be displayed
    /// </summary>
    public class ModelPositions
    {
        /// <summary>
        /// model of the objects to display
        /// </summary>
        private Model objectModel;
        /// <summary>
        /// list of positions of the object
        /// </summary>
        private List<Vector3> positions;
        /// <summary>
        /// list of directions of the object
        /// </summary>
        private List<Vector3> directions;
        /// <summary>
        /// resizingfactor to make the model bigger or smaller
        /// </summary>
        private float scaleValue = 1.0f;

        /// <summary>
        /// Constructor to initialise the model and its positions without specific directions
        /// </summary>
        /// <param name="objectModel">model to be displayed</param>
        /// <param name="positions">positions in a list to be displayed</param>
        public ModelPositions(Model objectModel, List<Vector3> positions)
        {
            this.objectModel = objectModel;
            this.positions = positions;
            this.directions = new List<Vector3>(positions.Count);

            for (int i = 0; i < directions.Count; ++i)
            {
                directions[i] = Vector3.Zero;
            }
        }

        /// <summary>
        /// Constructor to initialise the model and its positions with specific directions
        /// </summary>
        /// <param name="objectModel">model to be displayed</param>
        /// <param name="positions">positions in a list to be displayed</param>
        /// <param name="directions">directions in a list to turn the model to</param>
        public ModelPositions(Model objectModel, List<Vector3> positions, List<Vector3> directions)
        {
            this.objectModel = objectModel;
            this.positions = positions;
            this.directions = directions;
        }

        /// <summary>
        /// returns the count of positions available in the list
        /// </summary>
        /// <returns>count of available positions</returns>
        public int GetCount()
        {
            return positions.Count;
        }

        /// <summary>
        /// sets the factor to resize the model
        /// </summary>
        /// <param name="temp">factor to resize the model</param>
        public void setScale(float temp)
        {
            scaleValue = temp;
        }

        /// <summary>
        /// draws the models at each positions position and pointing to direction (or unurned if direction is (0,0,0)
        /// </summary>
        /// <param name="display">instance of the display class to be used to display the model</param>
        public void DrawObjects(ref Display display)
        {
            Random rnd = new Random();
            for(int i = 0; i < positions.Count; ++i)
            {
                display.DrawObject(objectModel, positions[i],Vector3.Zero, scaleValue);
            }
        }

        /// <summary>
        /// returns the specified position
        /// </summary>
        /// <param name="i">index of the position to be returned</param>
        /// <returns></returns>
        public Vector3 getPosition(int i)
        {
            return positions[i];
        }
    }
}
