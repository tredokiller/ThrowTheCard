using System;
using Common.Managers;
using Common.SpawnPoint;
using UnityEngine;


namespace Common.ObjectSpawner
{
    public class ObjectByPointSpawner : MonoBehaviour
    {
        [SerializeField] private ObjectPool.ObjectPool objectPool;
        [SerializeField] private SpawnPoints spawnPoints;

        private void OnEnable()
        {
            GameManager.onLevelStarted += () => SpawnObject(GameManager.CountOfFood);
        }

        public void SpawnObject(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var obj = objectPool.TryToGetRandomReadyObject();
                var point = spawnPoints.TryToGetRandomSpawnPoint();

                if (obj != null && point != null)
                {
                    obj.SetActive(true);
                    point.SetObjectToPoint(obj.transform);
                }
            }
        }
        
        private void OnDisable()
        {
            GameManager.onLevelStarted -= () => SpawnObject(GameManager.CountOfFood);
        }
    }
}
