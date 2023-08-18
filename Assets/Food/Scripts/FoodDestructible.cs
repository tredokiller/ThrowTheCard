using System;
using Common;
using Common.Destruction;
using UnityEngine;

namespace Food.Scripts
{
    public class FoodDestructible : DestructibleObjectBase
    {
        [SerializeField] private float rotationSpeed = 10f;

        public static Action onFoodDestructed;
        
        private void Update()
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Card.ToString()))
            {
                DestroyObject();
                onFoodDestructed.Invoke();
            }
        }
    }
}
