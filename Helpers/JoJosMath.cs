using Microsoft.Xna.Framework;
using System;

namespace JoJosMod.Helpers
{
    internal static class JoJosMath
    {
        public static double Distance(Vector2 point1, Vector2 point2)
        {
            return Math.Sqrt( Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2) );
        }
    }
}
