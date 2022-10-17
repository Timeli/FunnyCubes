using System;
using TMPro;
using UnityEngine;

namespace Assets.Code.UI
{
    public class ValueProvider : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _time;
        [SerializeField] private TMP_InputField _speed;
        [SerializeField] private TMP_InputField _distance;

        public Action<float> TimeChanged;
        public Action<float> SpeedChanged;
        public Action<float> DistanceChanged;

        private void Start()
        {
            _time.onValueChanged.AddListener(OnTimeChanged);   
            _speed.onValueChanged.AddListener(OnSpeedChanged);   
            _distance.onValueChanged.AddListener(OnDistanceChanged);   
        }

        private void OnDestroy()
        {
            _time.onValueChanged.RemoveListener(OnTimeChanged);   
            _speed.onValueChanged.RemoveListener(OnSpeedChanged);   
            _distance.onValueChanged.RemoveListener(OnDistanceChanged);   
        }

        public void SetTimeDirectly(float time) => 
            _time.text = Math.Round(time, 1).ToString();

        public void SetSpeedDirectly(float speed) => 
            _speed.text = Math.Round(speed, 1).ToString();

        public void SetDistanceDirectly(float distance) => 
            _distance.text = Math.Round(distance, 1).ToString();

        private void OnDistanceChanged(string text) => 
            TryChangeToFloat(text, DistanceChanged);

        private void OnTimeChanged(string text) => 
            TryChangeToFloat(text, TimeChanged);

        private void OnSpeedChanged(string text) => 
            TryChangeToFloat(text, SpeedChanged);

        private void TryChangeToFloat(string text, Action<float> action)
        {
            if (float.TryParse(text, out float result))
            {
                action?.Invoke(result);
            }
        }
    }
}