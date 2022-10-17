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

        private IUIController _controller;
        private ValueProvider _valueProvider;

        private float _elapsedTime;

        public void Construct(IUIController controller, ValueProvider valueProvider)
        {
            _controller = controller;
            _valueProvider = valueProvider;
            
            SubscribeToSliders();
            SubscribeToValueProvider();
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _time.value)
            {
                _controller.Update(_speed.value);
                _elapsedTime = 0;
            }
        }

        private void SubscribeToSliders()
        {
            _time.onValueChanged.AddListener(OnTimeChanged);
            _speed.onValueChanged.AddListener(OnSpeedChanged);
        }

        private void OnDestroy()
        {
            _time.onValueChanged.RemoveListener(OnTimeChanged);
            _speed.onValueChanged.RemoveListener(OnSpeedChanged);
        }

        private void SubscribeToValueProvider()
        {
            _valueProvider.TimeChanged += SetTime;
            _valueProvider.SpeedChanged += SetSpeed;
        }

        private void OnSpeedChanged(float speed) => 
            _valueProvider.SetSpeedDirectly(speed);

        private void OnTimeChanged(float time) =>
            _valueProvider.SetTimeDirectly(time);

        private void SetTime(float time) => _time.value = time;
        private void SetSpeed(float speed) => _speed.value = speed;
    }
}