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

        public void SetTimeDirectly(float time) => 
            _time.text = Math.Round(time, 1).ToString();

        public void SetSpeedDirectly(float speed) => 
            _speed.text = Math.Round(speed, 1).ToString();

        private void OnTimeChanged(string text) => 
            TryChangeToFloat(text, TimeChanged);

        private void OnSpeedChanged(string text) => 
            TryChangeToFloat(text, SpeedChanged);

        private void TryChangeToFloat(string text, Action<float> action)
        {
            if (float.TryParse(text, out float result))
            {
                Debug.Log(result);
                action?.Invoke(result);
            }
        }
    }
}