using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ACT2009
{
    class Objecthandler
    {
        String[] objectType;
        Vector3[,] objects;

        public String getObjectType(int dimension)
        {
            if (objectType.GetLength(0) > dimension)
            {
                return objectType[dimension];
            }
            return null;
        }

        public Vector3 getPosition(int dimension, int index)
        {
            if (objects.Rank > dimension)
            {
                if (objects.GetLength(dimension) > index)
                {
                    return objects[dimension, index];
                }
            }
            //hack To indicate no return-value
            return new Vector3(0);
        }
    }
}
