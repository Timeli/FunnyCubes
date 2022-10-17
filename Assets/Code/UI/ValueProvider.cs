using System;
using TMPro;
using UnityEngine;

namespace Assets.Code.UI
{
    public class ValueProvider : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _time;
        [SerializeField] private TMP_InputField _speed;

        public Action<float> TimeChanged;
        public Action<float> SpeedChanged;

        private void Start()
        {
            _time.onValueChanged.AddListener(OnTimeChanged);   
            _speed.onValueChanged.AddListener(OnSpeedChanged);   
        }

        private void OnDestroy()
        {
            _time.onValueChanged.RemoveListener(OnTimeChanged);   
            _speed.onValueChanged.RemoveListener(OnSpeedChanged);   
        }

        private void OnTimeChanged(string text)
        {
            TryChangedToFloat(text, TimeChanged);
        }

        private void OnSpeedChanged(string text)
        {
            TryChangedToFloat(text, SpeedChanged);
        }

        private void TryChangedToFloat(string text, Action<float> action)
        {
            if (float.TryParse(text, out float result))
            {
                Debug.Log(result);
                action?.Invoke(result);
            }
        }
    }
}