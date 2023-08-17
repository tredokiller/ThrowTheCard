using UnityEngine;


namespace Common.SpawnPoint
{
    [RequireComponent(typeof(MeshRenderer))]
    public class SpawnPoint : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;

        [SerializeField] private SpawnPoint[] trajectoryMovementPoints; //Points for trajectory movement

        private bool _hasMovementByTrajectory; //Possibility to move by trajectory
        private bool _isMovementByTrajectory; //Will move by trajectory if _hasMovementByTrajectory = true and random bool = true
        
        private Transform _pointObject;
        public bool IsFree { private set; get; }
        
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.enabled = false;

            if (trajectoryMovementPoints.Length > 0)
            {
                _hasMovementByTrajectory = true;
            }
        }

        private void Update()
        {
            if (_isMovementByTrajectory)
            {
                var actualPosition = _pointObject.position;
                _pointObject.position = Vector3.MoveTowards(actualPosition, trajectoryMovementPoints[x].position,
                    speed * Time.deltaTime);
            }
        }

        public void SetObjectToPoint(Transform objTransform)
        {
            _pointObject = objTransform;
            _pointObject.position = transform.position;

            if (_hasMovementByTrajectory && Randomizer.GetRandomBool())
            {
                _isMovementByTrajectory = true;
            }
            else
            {
                _isMovementByTrajectory = false; 
            }

            IsFree = false;
        }

        public void ResetPointData()
        {
            IsFree = true;
            
            _pointObject = null;
        }
    }
}
