using System;
using System.Threading.Tasks;
using Sample1Scripts;
using UnityEngine;

namespace Sample3Scripts
{
    public class AwaitAsyncTaskSample3 : MonoBehaviour
    {
        [SerializeField] AwaitAsyncTaskSample[] _samples;

        [ContextMenu(nameof(StartRotation1))]
        public async void StartRotation1()
        {
            for (int i = 0; i < _samples.Length; i++)
            {
                _samples[i].StartRotation();
                await Task.Delay(2000);
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }
        
        [ContextMenu(nameof(StartRotation2))]
        public async void StartRotation2()
        {
            for (int i = 0; i < _samples.Length; i++)
            {
                bool result = await _samples[i].StartRotationAndReturnBool();
                Debug.Log(result);
            }
        }
    }
}