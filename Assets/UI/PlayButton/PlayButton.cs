using System;
using Common.Managers;
using Common.Transition;
using UnityEngine;

namespace UI.PlayButton
{
    [RequireComponent(typeof(TwoSidesTransition))]
    public class PlayButton : MonoBehaviour
    {
        private TwoSidesTransition _twoSidesTransition;
        
        public static Action onPlayButtonClicked;

        private void Awake()
        {
            _twoSidesTransition = GetComponent<TwoSidesTransition>();
        }

        private void OnEnable()
        {
            GameManager.onLevelFinished += _twoSidesTransition.ToTransition;
        }

        public void PlayButtonClicked()
        {
            _twoSidesTransition.FromTransition();
            onPlayButtonClicked.Invoke();
        }
        
        

        private void OnDisable()
        {
            GameManager.onLevelFinished -= _twoSidesTransition.ToTransition;
        }
    }
}
