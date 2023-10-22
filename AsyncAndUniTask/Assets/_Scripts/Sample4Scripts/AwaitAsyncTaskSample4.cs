using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Sample4Scripts
{
    public class AwaitAsyncTaskSample4 : MonoBehaviour
    {
        [SerializeField] float _speed = 100f;
        [SerializeField] float _maxTime = 10f;
        [SerializeField] Transform _transform;

        float _currentTime = 0f;
        CancellationTokenSource _tokenSource;
        CancellationToken _cancellationToken;

        void OnValidate()
        {
            if (_transform == null) _transform = GetComponent<Transform>();
        }

        async void Start()
        {
            _tokenSource = new CancellationTokenSource();
            _cancellationToken = _tokenSource.Token;
            //await StartRotationAsync1();
            await StartRotationAsync2();
        }

        private async Task StartRotationAsync1()
        {
            while (_currentTime < _maxTime)
            {
                if (_cancellationToken.IsCancellationRequested) break;
                
                float deltaTime = Time.deltaTime;
                _currentTime += deltaTime;
                _transform.Rotate(_speed * deltaTime * Vector3.up);
                await Task.Yield();
            }

            _currentTime = 0f;
        }
        
        private async Task StartRotationAsync2()
        {
            while (_currentTime < _maxTime)
            {
                float deltaTime = Time.deltaTime;
                _currentTime += deltaTime;
                _transform.Rotate(_speed * deltaTime * Vector3.up);
                await Task.Delay(100, _cancellationToken);
            }

            _currentTime = 0f;
        }

        [ContextMenu(nameof(CancelAsyncOperation))]
        private void CancelAsyncOperation()
        {
            _tokenSource.Cancel();
        }
    }
}