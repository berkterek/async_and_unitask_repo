﻿using System.Threading.Tasks;
using UnityEngine;

namespace Sample1Scripts
{
    public class AwaitAsyncTaskSample2 : MonoBehaviour
    {
        [SerializeField] float _speed = 100f;
        [SerializeField] float _maxTime = 3f;
        [SerializeField] Transform _transform;

        float _currentTime = 0f;

        void OnValidate()
        {
            if (_transform == null) _transform = GetComponent<Transform>();
        }

        // async void Awake()
        // {
        //     await StartRotationAsync();
        //     Debug.Log("Awake working after 3 seconds");
        // }

        // async void Start()
        // {
        //     await StartRotationAsync();
        //     Debug.Log("Start working after 3 seconds");
        // }
        
        // void OnEnable()
        // {
        //     StartRotationAsync();
        //     Debug.Log("Enable working immediately");
        // }

        private async Task StartRotationAsync()
        {
            while (_currentTime < _maxTime)
            {
                float deltaTime = Time.deltaTime;
                _currentTime += deltaTime;
                _transform.Rotate(_speed * deltaTime * Vector3.up);
                await Task.Yield();
            }

            _currentTime = 0f;
        }
    }
}