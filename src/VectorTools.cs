using System;
using Godot;


public static class Vector2Extansions 
{
    public static double Rad2Deg(double radians)
    {   
        return radians * (180 / Math.PI);
    }


    public static int Degree2Index(this Vector2 vector, double degree_step)
    {
        if (360 % degree_step != 0)
        {
            // TODO(g3k1): find way to explain this condition
            throw new ArgumentException(
                $"360 can't be divided by step properly : {degree_step}"
            );
        }
        if (vector == Vector2.Zero)
        {
            throw new ArgumentException(String.Format(
                "Vector can't be equal Vector2.ZERO: {0}", vector
            ));
        }
        if (!vector.IsNormalized())
        {
            throw new ArgumentException(String.Format(
                "Vector should be normalized: {0}", vector
            ));
        }

        double radians = vector.Angle();
        double degree = Math.Round(Rad2Deg(radians));
        
        if (degree < 0)
        {
            degree = 2 * 180 + degree;
        }

        Logger.Debug("rad({0}) = {1}", vector, radians);
        Logger.Debug("rad [{0}] -> deg [{1}]", radians, degree);

        return (int)Math.Round(degree / degree_step);
    }
}