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
        public static UpdateMovementAnimation(Transform transform, Vector3 velocity, Animator animator)
        {
            var movementDirection = velocity;
            var faceForward = Quaternion.FromToRotation(transform.forward, Vector3.forward);
            var relativeMovementDirection = faceForward * movementDirection;

            var forward = relativeMovementDirection.y;
            var right = relativeMovementDirection.z;

            animator.SetFloat("InputX", forward);
            animator.SetFloat("InputY", right);
        }
        
        public void MoveVRCharacter(Vector3 sanitizedInput, Vector3 cameraDirection, Transform playerObject)
        {
            var faceForward = Quaternion.FromToRotation(playerObject.forward, cameraDirection);
            var relativeMovementDirection = faceForward * sanitizedInput;

            var forward = relativeMovementDirection.z;
            var right = relativeMovementDirection.x;
            playerObject.transform.position += new Vector3(right, 0, forward) * 5 * Time.deltaTime;
        }
    }
}
