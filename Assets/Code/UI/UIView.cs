using Cubes;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private Slider _time;
        [SerializeField] private Slider _speed;

        private IUIController _controller;
        private ICubeModel _cubeModel;
        private IObjectPool _objectPool;
        private IGameFactory _gameFactory;

        private float _elapsedTime;

        private void Start()
        {
            _gameFactory = new GameFactory();
            _objectPool = new ObjectPoolService();
            _objectPool.Init(_gameFactory, 30);
            _cubeModel = new CubeModel();
            _controller = new UIController(_cubeModel, _objectPool);
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
    } 
}