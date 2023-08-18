using System;
using System.Linq;
using Common.Camera;
using Food.Scripts;
using Input.InputManager;
using UnityEngine;
using UnityEngine.Serialization;

namespace Common.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        
        public static Action onLevelStarted;
        public static Action onLevelFinished;


        private int _foodDestructed = 0;
        public const int CountOfFood = 4;


        private void Awake()
        {
            SetFrameRate();
        }

        private void OnEnable()
        {
            FoodDestructible.onFoodDestructed += FoodDestructed;
            CameraSettings.onCameraReady += StartLevel;
        }

        private void FoodDestructed()
        {
            _foodDestructed += 1;
            
            if (_foodDestructed >= CountOfFood) 
            {
                FinishLevel();
            }
        }

        private void SetFrameRate()
        {
            QualitySettings.vSyncCount = 0;
            
            Resolution[] refreshRate = Screen.resolutions;
            Application.targetFrameRate = refreshRate.Last().refreshRate;

        }
        
        private void FinishLevel()
        {
            inputManager.gameObject.SetActive(false);
            onLevelFinished.Invoke();
        }

        private void Start()
        {
            StartLevel();
        }


        public void StartLevel()
        {
            inputManager.gameObject.SetActive(true);
            
            _foodDestructed = 0;
            onLevelStarted?.Invoke();
        }

        private void OnDisable()
        {
            CameraSettings.onCameraReady -= StartLevel;
            FoodDestructible.onFoodDestructed -= FoodDestructed;
        }
    }
}
