using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class Vector3Data
    {
        public Vector3Data()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public Vector3Data(float fX, float fY, float fZ)
        {
            x = fX;
            y = fY;
            z = fZ;
        }
        public float x;
        public float y;
        public float z;
    }
}
