using Assets.Code;
using Assets.Code.UI;
using Cubes;
using Services;
using UI;

namespace Game
{
    public class Game
    {
        private IGameFactory _gameFactory;
        private IObjectPool _objectPool;
        private ICubeModel _cubeModel;
        private IUIController _controller;

        public Game()
        {
            InitComponents();
            CreateScene();
        }

        private void InitComponents()
        {
            _gameFactory = new GameFactory();

            _objectPool = new ObjectPoolService(_gameFactory);
            _objectPool.Init(ObjectForCreate.Cube, Constants.CubesPullCapacity);

            _cubeModel = new CubeModel();

            _controller = new UIController(_cubeModel, _objectPool);
        }

        private void CreateScene()
        {
            UIView uiView = CreateUI();
            CreateCurtain(uiView);
            CreateWall(uiView);
        }

        private void CreateCurtain(UIView uiView)
        {
            var curtainPrefab = _gameFactory.Create(ObjectForCreate.Curtain);
            curtainPrefab.GetComponent<CurtainLogic>().Construct(uiView);
        }

        private UIView CreateUI()
        {
            var uiPrefab = _gameFactory.Create(ObjectForCreate.UiView);

            ValueProvider valueProvider = uiPrefab.GetComponentInChildren<ValueProvider>();
            UIView uiView = uiPrefab.GetComponentInChildren<UIView>();
            ToggleProvider toggleProvider = uiPrefab.GetComponentInChildren<ToggleProvider>();

            uiView.Construct(_controller, valueProvider, toggleProvider);
            return uiView;
        }

        private void CreateWall(UIView uiView)
        {
            var wallPrefab = _gameFactory.Create(ObjectForCreate.Wall);
            Wall wall = wallPrefab.GetComponentInChildren<Wall>();
            wall.Construct(uiView);
        }
    }
}