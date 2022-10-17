using Assets.Code.UI;
using Cubes;
using Services;
using UI;

namespace Game
{
    public class Game
    {
        private const int PullCapacity = 50;

        private IGameFactory _gameFactory;
        private IObjectPool _objectPool;
        private ICubeModel _cubeModel;
        private IUIController _controller;

        public Game()
        {
            InitComponents();
            
            CreateScene();
        }

        private void CreateScene()
        {
            var uiPrefab = _gameFactory.Create(ObjectForCreate.UiView);

            ValueProvider valueProvider = uiPrefab.GetComponentInChildren<ValueProvider>();
            UIView uiView = uiPrefab.GetComponentInChildren<UIView>();
            
            uiView.Construct(_controller, valueProvider);
        }

        private void InitComponents()
        {
            _gameFactory = new GameFactory();

            _objectPool = new ObjectPoolService(_gameFactory);
            _objectPool.Init(ObjectForCreate.Cube, PullCapacity);

            _cubeModel = new CubeModel();

            _controller = new UIController(_cubeModel, _objectPool);
        }
    }
}