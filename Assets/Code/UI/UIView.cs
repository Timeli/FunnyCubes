using Assets.Code.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private Slider _time;
        [SerializeField] private Slider _speed;
        [SerializeField] private Slider _distance;

        private IUIController _controller;
        private ValueProvider _valueProvider;
        private ToggleProvider _toggleProvider;

        private bool _withColor;
        private bool _withRandom;
        private bool _withRotate;
        
        private float _elapsedTime;

        public void Construct(IUIController controller, ValueProvider valueProvider, ToggleProvider toggleProvider)
        {
            _controller = controller;
            _valueProvider = valueProvider;
            _toggleProvider = toggleProvider;

            SubscribeToSliders();
            SubscribeToValueProvider();
            SubscribeToToggles();
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _time.value)
            {
                _controller.Update(_speed.value, _withColor, _withRandom, _withRotate);
                _elapsedTime = 0;
            }
        }

        private void SetTime(float time) => _time.value = time;
        private void SetSpeed(float speed) => _speed.value = speed;
        private void SetDistance(float distance) => _distance.value = distance;

        private void SetRotate(bool value) => _withRotate = value;
        private void SetRandom(bool value) => _withRandom = value;
        private void SetColor(bool value) => _withColor = value;

        private void OnSpeedChanged(float speed) => _valueProvider.SetSpeedDirectly(speed);
        private void OnTimeChanged(float time) => _valueProvider.SetTimeDirectly(time);
        
        public Action<float> DistanceChanged;
        private void OnDistanceChanged(float distance)
        {
            _valueProvider.SetDistanceDirectly(distance);
            DistanceChanged?.Invoke(distance);
        }

        private void SubscribeToValueProvider()
        {
            _valueProvider.TimeChanged += SetTime;
            _valueProvider.SpeedChanged += SetSpeed;
            _valueProvider.DistanceChanged += SetDistance;
        }

        private void SubscribeToToggles()
        {
            _toggleProvider.OnColorChanged += SetColor;
            _toggleProvider.OnRandomChanged += SetRandom;
            _toggleProvider.OnRotateChanged += SetRotate;
        }

        private void SubscribeToSliders()
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
    }
}