using System;
using System.Collections;
using UnityEngine;

namespace Player.Trajectory.Scripts
{
    
    public static class BezierCurve
    {
        public static Vector3 CalculateQuadraticBezierPoint(float t, Vector3 pos0, Vector3 pos1, Vector3 pos2)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            Vector3 p = uu * pos0;

            p += 2 * u * t * pos1;
            p += tt * pos2;
            return p;
        }


        public static IEnumerator MoveByQuadraticBezierCoroutine(Transform obj,  
            float duration, Vector3 pos0, Vector3 pos1, Vector3 pos2, Action finishedCallback = null)
        {
            float currentTime = 0;
            bool hasFinishedCallback = finishedCallback != null;
            while (currentTime < duration)
            {
                float t = currentTime / duration;
                
                currentTime += Time.deltaTime;

                obj.position = CalculateQuadraticBezierPoint(t, pos0, pos1, pos2);
                yield return null ;
            }
            
            if (hasFinishedCallback)
            {
                finishedCallback.Invoke();
            }
        }
    }
}
