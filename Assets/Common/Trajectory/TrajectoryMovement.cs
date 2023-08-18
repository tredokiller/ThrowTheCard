using UnityEngine;

namespace Common.Trajectory
{
    public static class TrajectoryMovement
    {
        public static void MoveAlongTrajectory(ref int currentPointIndex, Transform objectToMove, Transform[] trajectoryPoints, 
            float speed , bool isLoop = false)
        {
            var currentTrajectoryPointIndex = currentPointIndex;
            
            if (currentPointIndex < 0)
            {
                currentTrajectoryPointIndex = trajectoryPoints.Length + currentPointIndex;
                if (currentTrajectoryPointIndex == 0)
                {
                    currentPointIndex = currentTrajectoryPointIndex;
                }
            }
            
            Vector3 actualPosition = objectToMove.position;
            Vector3 targetPosition = trajectoryPoints[currentTrajectoryPointIndex].position;

            // Move towards the current target point
            objectToMove.position = Vector3.MoveTowards(actualPosition, targetPosition, speed * Time.deltaTime);

            // Check if the object has reached the current point
            if (objectToMove.position == targetPosition)
            {
                if (currentPointIndex >= 0)
                {
                    if (currentPointIndex < trajectoryPoints.Length - 1)
                    {
                        currentPointIndex++;
                    }

                    if (isLoop)
                    {
                        if (currentPointIndex >= trajectoryPoints.Length - 1)
                        {
                            currentPointIndex = -1;
                            return;
                        } 
                    }
                }

                if (isLoop && currentPointIndex < 0)
                {
                    currentPointIndex--;
                }
            }
        }
    }
}