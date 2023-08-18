using System;
using UnityEngine;

namespace Card.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Card : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Vector3 _previousPosition;

        [SerializeField] private float rotationSpeed = 75f;
        private const float MinVelocityMagnitude = 0.01f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _previousPosition = _rigidbody.position;
        }

        void Update()
        {
            Vector3 velocity = (_rigidbody.position - _previousPosition) / Time.deltaTime;
            if (velocity.magnitude > MinVelocityMagnitude)
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
    
            _previousPosition = _rigidbody.position;
        }
    }
}
