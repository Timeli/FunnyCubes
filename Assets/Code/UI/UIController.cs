using Cubes;
using Services;

namespace UI
{
    public class UIController : IUIController
    {
        private readonly ICubeModel _cubeModel;
        private readonly IObjectPool _objectPool;

        public UIController(ICubeModel cubeModel, IObjectPool objectPool)
        {
            _cubeModel = cubeModel;
            _objectPool = objectPool;
        }

        public void Update(float speed)
        {
            UnityEngine.GameObject cube = _objectPool.GetNextItem();
            _cubeModel.Fly(cube, speed);
        }
    }
}