using System;
using UnityEngine;

namespace Player.Trajectory.Scripts
{
    [RequireComponent(typeof(LineRenderer))]
    public class BezierCurveController: MonoBehaviour
    {
        [Header("Points")]
        [SerializeField] private Transform startPoint;
        [SerializeField] private Transform middlePoint;
        [SerializeField] private Transform finalPoint;
        
        
        private const float HorizontalMovementMultiplier = 2.2f;
        private const float VerticalMovementMultiplier = 2.5f;
        
        private Vector3 _startMiddlePointPosition;
        
        private LineRenderer _bezierLineRenderer;

        private const int NumberOfPoints = 70;

        private void Awake()
        {
            _bezierLineRenderer = GetComponent<LineRenderer>();
            _startMiddlePointPosition = middlePoint.position;
        }

        public void DrawQuadraticPath()
        {
            _bezierLineRenderer.positionCount = NumberOfPoints;
            Vector3[] positions = new Vector3[NumberOfPoints];
            for (int i = 1; i < NumberOfPoints + 1; i++)
            {
                float time = i / (float)NumberOfPoints;
                positions[i - 1] = BezierCurve.CalculateQuadraticBezierPoint
                    (time, startPoint.position, middlePoint.position, finalPoint.position);
            }
            _bezierLineRenderer.SetPositions(positions);
        }
        
        public void MoveCenterOfCurve(Vector2 position)
        {
            var newHorizontalPos = _startMiddlePointPosition.x + position.x * HorizontalMovementMultiplier;
            var newVerticalPos = _startMiddlePointPosition.z + position.y * VerticalMovementMultiplier;
            
            middlePoint.position = new Vector3(newHorizontalPos,
                _startMiddlePointPosition.y, newVerticalPos);
        }
        

        public void MoveByQuadraticPath(Transform obj , float duration , Action finishedCallback = null)
        {
            StartCoroutine(BezierCurve.MoveByQuadraticBezierCoroutine
                (obj, duration, startPoint.position, middlePoint.position, finalPoint.position , finishedCallback));
        }
        
        public void ClearPath()
        {
            _bezierLineRenderer.positionCount = 0;
        }
    }
}