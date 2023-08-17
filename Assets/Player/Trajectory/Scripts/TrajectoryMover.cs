using UnityEngine;

namespace Player.Trajectory.Scripts
{
    public class TrajectoryMover : MonoBehaviour
    {
        [SerializeField] private Transform middlePointOfTrajectory;
        private Vector3 _startMiddlePointPosition;

        private const float HorizontalMovementMultiplier = 2f;
        private const float VerticalMovementMultiplier = 2f;

        private void Awake()
        {
            _startMiddlePointPosition = middlePointOfTrajectory.position;
        }

        public void Move(Vector2 position)
        {
            var newHorizontalPos = _startMiddlePointPosition.x + position.x * HorizontalMovementMultiplier;
            var newVerticalPos = _startMiddlePointPosition.z + position.y * VerticalMovementMultiplier;
            
            middlePointOfTrajectory.position = new Vector3(newHorizontalPos,
                _startMiddlePointPosition.y, newVerticalPos);
        }
    }
}
