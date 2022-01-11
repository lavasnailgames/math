using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VikiMath
{
    public class VikiMath
    {
        public static float Interpolate(float input, float minInput, float maxInput, float minOutput, float maxOutput, bool invert = false)
        {
            if (invert)
            {
                input *= -1;
                (minInput, maxInput) = (-maxInput, -minInput);
            }
            return (input - minInput) / (maxInput - minInput) * (maxOutput - minOutput) + minOutput;
        }
        public static int RandomIndex(List<float> probabilities)
        {
            var sum = probabilities.Sum();
            var random = Random.Range(0f, sum);
            for (var index = 0; index < probabilities.Count; ++index)
            {
                var probability = probabilities[index];
                if (random < probability)
                {
                    return index;
                }
                random -= probability;
            }
            return probabilities.Count - 1;
        }
    }
}
