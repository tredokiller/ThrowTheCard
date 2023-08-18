using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace Common.SpawnPoint
{
    public class SpawnPoints : MonoBehaviour
    {
        private SpawnPoint[] _spawnPoints;
        
        private void Awake()
        {
            _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        }

        [CanBeNull]
        public SpawnPoint TryToGetRandomSpawnPoint()
        {
            var freePoints = GetAllFreePoints();

            if (freePoints.Length > 0)
            {
                return freePoints[Randomizer.GetRandomIndexFromArray(freePoints.Length)];
            }

            return null;

        }
        
        private SpawnPoint[] GetAllFreePoints()
        {
            List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

            foreach (var point in _spawnPoints)
            {
                if (point.IsFree)
                {
                    spawnPoints.Add(point);
                }
            }

            return spawnPoints.ToArray();
        }
        
    }
}
