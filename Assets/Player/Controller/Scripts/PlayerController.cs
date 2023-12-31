using System;
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

        [SerializeField] private GameObject throwObject;
        
        private Vector2 _inputPlayer;
        
        [Header("Card")] 
        [SerializeField] private float cardSpeed = 1;

        private bool _canThrowCard = true;

        private void UpdateInputPlayer()
        {
            _inputPlayer = inputManager.PlayerActions.Movement.ReadValue<Vector2>();
        }

        private void OnEnable()
        {
            inputManager.PlayerActions.Touch.canceled += context => TryToThrowCard();
        }

        private void Update()
        {
            UpdateInputPlayer();

            if (_inputPlayer != Vector2.zero)
            {
                UpdateThrowTrajectory();
            }
            else
            {
                bezierCurveController.ClearPath();
            }
        }

        private void TryToThrowCard()
        {
            if (_canThrowCard)
            {
                throwObject.SetActive(false);
                bezierCurveController.MoveByQuadraticPath(throwObject.transform, cardSpeed , (() => _canThrowCard = true));
                throwObject.SetActive(true);
                
                _canThrowCard = false;
            }
        }

        private void UpdateThrowTrajectory()
        {
            bezierCurveController.DrawQuadraticPath();
            bezierCurveController.MoveCenterOfCurve(_inputPlayer);
        }

        private void OnDisable()
        {
            inputManager.PlayerActions.Touch.canceled -= context => TryToThrowCard();
        }
    }
}
