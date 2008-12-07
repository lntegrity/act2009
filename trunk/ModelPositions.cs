using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ACT2009
{
    class ModelPositions
    {
        //model of the objects to display
        private Model objectModel;
        //list of positions of the object
        private List<Vector3> positions;
        //list of directions of the object
        private List<Vector3> directions;

        ModelPositions(Model objectModel,List<Vector3> positions)
        {
            this.objectModel = objectModel;
            this.positions = positions;
            this.directions = new List<Vector3>(positions.Count);

            for (int i = 0; i < directions.Count; ++i)
            {
                directions[i] = Vector3.Zero;
            }
        }
        ModelPositions(Model objectModel,List<Vector3> positions,List<Vector3> directions)
        {
            this.objectModel = objectModel;
            this.positions = positions;
            this.directions = directions;
        }
    }
}
