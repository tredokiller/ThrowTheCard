using System;
using UnityEngine;

namespace Input.InputManager
{
    public class InputManager : MonoBehaviour
    {
        private GameInput _gameInput;
        public GameInput.PlayerActions PlayerActions { private set; get; }

        private void Awake()
        {
            _gameInput = new GameInput();
            PlayerActions = _gameInput.Player;
        }

        private void OnEnable()
        {
            _gameInput.Enable();
        }

        private void OnDisable()
        {
            _gameInput.Disable();
        }
    }
}
