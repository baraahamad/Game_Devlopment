using UnityEngine;

namespace Assignment18
{
    // Step 2: Define a Struct Position
    public struct Position
    {
        public float X, Y, Z;

        public Position(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void PrintPosition()
        {
            Debug.Log($"Position: X={X}, Y={Y}, Z={Z}");
        }
    }

}
