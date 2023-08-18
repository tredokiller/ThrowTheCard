using System.Collections.Generic;
using Common.Managers;
using JetBrains.Annotations;
using UnityEngine;

namespace Common.ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        private GameObject[] _gameObjects;

        private void Awake()
        {
            _gameObjects = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
               _gameObjects[i] = transform.GetChild(i).gameObject;
                
            }
        }
        
        private void OnEnable()
        {
            GameManager.onLevelStarted += () => ActivateAllObjects(false);
        }

        public void ActivateAllObjects(bool isActive)
        {
            foreach(var obj in _gameObjects)
            {
                obj.SetActive(isActive);
            }
        }

        [CanBeNull]
        public GameObject TryToGetRandomReadyObject()
        {
            var readyObjects = GetAllReadyObjects();
            if (readyObjects.Length > 0)
            {
                return readyObjects[Randomizer.GetRandomIndexFromArray(readyObjects.Length)];
            }

            return null;
        }

        private GameObject[] GetAllReadyObjects()
        {
            List<GameObject> readyObjects = new List<GameObject>();

            foreach (var obj in _gameObjects)
            {
                if (obj.activeSelf == false)
                {
                    readyObjects.Add(obj);
                }
            }

            return readyObjects.ToArray();
        }

        private void OnDisable()
        {
            GameManager.onLevelStarted += () => ActivateAllObjects(false);
        }
    }
}
