using System;
using DG.Tweening;
using UI.PlayButton;
using UnityEngine;

namespace Common.Camera
{
    public class CameraSettings : MonoBehaviour
    {
        private const float DefaultAngle = 50;
        private const float TransitionAngle = -40;

        private float _transitionDuration = 0.5f;

        public static Action onCameraReady;
        
        private void OnEnable()
        {
            PlayButton.onPlayButtonClicked += CameraMakeTransition;
        }
        
        
        private void CameraMakeTransition()
        {
            Quaternion newRotation = Quaternion.Euler(TransitionAngle, 0, 0);
            transform.DORotate(newRotation.eulerAngles, _transitionDuration).OnComplete(ResetCameraRotation);
        }

        private void ResetCameraRotation()
        {
            onCameraReady.Invoke();
            transform.DORotate(new Vector3(DefaultAngle, 0, 0), _transitionDuration);
        }
        
        private void OnDisable()
        {
            PlayButton.onPlayButtonClicked -= CameraMakeTransition;
        }
        
    }
    
    
    
}
