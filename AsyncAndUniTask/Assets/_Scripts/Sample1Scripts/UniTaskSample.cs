﻿using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Sample1Scripts
{
    public class UniTaskSample : MonoBehaviour
    {
        [SerializeField] float _speed = 100f;
        [SerializeField] float _maxTime = 3f;
        [SerializeField] Transform _transform;

        float _currentTime = 0f;

        void OnValidate()
        {
            if (_transform == null) _transform = GetComponent<Transform>();
        }
        
        [ContextMenu(nameof(StartRotation))]
        public void StartRotation()
        {
            StartRotationAsync();
        }
        
        private async void StartRotationAsync()
        {
            while (_currentTime < _maxTime)
            {
                float deltaTime = Time.deltaTime;
                _currentTime += deltaTime;
                _transform.Rotate(_speed * deltaTime * Vector3.up);
                await UniTask.Yield();
            }

            _currentTime = 0f;
        }
    }
}