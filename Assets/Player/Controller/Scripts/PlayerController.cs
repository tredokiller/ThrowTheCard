using Input.InputManager;
using Player.Trajectory.Scripts;
using UnityEngine;


namespace Player.Controller.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField] private InputManager inputManager;
        [SerializeField] private BezierCurveController bezierCurveController;

        [SerializeField] private GameObject obj;
        
        private Vector2 _inputPlayer;
        
        [Header("Card")] 
        [SerializeField] private float cardSpeed = 1;
        private bool _canThrowCard;
        

        [Header("Trajectory")] 
        [SerializeField] private TrajectoryMover trajectoryMover;

        private void UpdateInputPlayer()
        {
            _inputPlayer = inputManager.PlayerActions.Movement.ReadValue<Vector2>();
        }

        private void Update()
        {
            UpdateInputPlayer();

            if (_inputPlayer != Vector2.zero)
            {
                UpdateThrowTrajectory();
                _canThrowCard = true;
            }
            else
            {
                if (_canThrowCard)
                {
                    ThrowCard();
                    _canThrowCard = false;
                }
                bezierCurveController.ClearPath();
            }
        }

        private void ThrowCard()
        {
           bezierCurveController.MoveByQuadraticPath(obj.transform, cardSpeed); 
        }

        private void UpdateThrowTrajectory()
        {
            bezierCurveController.DrawQuadraticPath();
            trajectoryMover.Move(_inputPlayer);
        }
    }
}
