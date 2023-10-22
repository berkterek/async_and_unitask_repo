using System;
using Cysharp.Threading.Tasks;
using Sample1Scripts;
using UnityEngine;

namespace Sample3Scripts
{
    public class UniTaskSample3 : MonoBehaviour
    {
        [SerializeField] UniTaskSample[] _samples;

        [ContextMenu(nameof(StartRotation1))]
        public async void StartRotation1()
        {
            for (int i = 0; i < _samples.Length; i++)
            {
                _samples[i].StartRotation();
                //await UniTask.Delay(2000, false, PlayerLoopTiming.Update);
                await UniTask.Delay(TimeSpan.FromSeconds(2), false, PlayerLoopTiming.Update);
            }
        }
        
        [ContextMenu(nameof(StartRotation2))]
        public async void StartRotation2()
        {
            for (int i = 0; i < _samples.Length; i++)
            {
                bool result = await _samples[i].StartRotationAndReturnBool();
                Debug.Log(result);
                //await UniTask.WaitUntil(() => result);
            }
        }
    }
}