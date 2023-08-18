using System;
using Common.Managers;
using Common.Trajectory;
using UnityEngine;


namespace Common.SpawnPoint
{
    [RequireComponent(typeof(MeshRenderer))]
    public class SpawnPoint : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;

        [SerializeField] private Transform[] trajectoryMovementPoints; //Points for trajectory movement
        private int _currentTrajectoryPointIndex = 0;
        
        private bool _hasMovementByTrajectory; //Possibility to move by trajectory
        private bool _isMovementByTrajectory; //Will move by trajectory if _hasMovementByTrajectory = true and random bool = true
        
        private Transform _pointObject;
        private const float PointMoveSpeed = 2f;
        
        public bool IsFree { private set; get; }
        
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.enabled = false;
            
            ResetPointData();

            if (trajectoryMovementPoints.Length > 0)
            {
                _hasMovementByTrajectory = true;
            }
        }

        private void OnEnable()
        {
            GameManager.onLevelStarted += ResetPointData;
        }

        private void Update()
        {
            if (_isMovementByTrajectory)
            {
                TrajectoryMovement.MoveAlongTrajectory(ref _currentTrajectoryPointIndex, _pointObject.transform, trajectoryMovementPoints , PointMoveSpeed , true);
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

        private void ResetPointData()
        {
            IsFree = true;
            _isMovementByTrajectory = false;
            _pointObject = null;
        }
        
        private void OnDisable()
        {
            GameManager.onLevelStarted -= ResetPointData;
        }

       
    }
}
