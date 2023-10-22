using System.Collections;
using UnityEngine;

namespace Sample1Scripts
{
    public class CoroutineSample : MonoBehaviour
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
            StartCoroutine(StartRotationAsync());
        }

        private IEnumerator StartRotationAsync()
        {
            while (_currentTime < _maxTime)
            {
                float deltaTime = Time.deltaTime;
                _currentTime += deltaTime;
                _transform.Rotate(_speed * deltaTime * Vector3.up);
                yield return null;
            }

            _currentTime = 0f;
        }
    }    
}

