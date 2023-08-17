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
        
        private LineRenderer _bezierLineRenderer;

        private const int NumberOfPoints = 70;

        private void Awake()
        {
            _bezierLineRenderer = GetComponent<LineRenderer>();
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

        public void MoveByQuadraticPath(Transform obj , float duration)
        {
            StartCoroutine(BezierCurve.MoveByQuadraticBezierCoroutine
                (obj, duration, startPoint.position, middlePoint.position, finalPoint.position));
        }
        
        public void ClearPath()
        {
            _bezierLineRenderer.positionCount = 0;
        }
    }
}