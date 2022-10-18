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

        public void Update(float speed, bool color, bool random)
        {
            UnityEngine.GameObject cube = _objectPool.GetNextItem();

            if (random && color)
            {
                _cubeModel.FlyColorRandom(cube, speed);
            }
            else if (random)
            {
                _cubeModel.FlyRandom(cube, speed);
            }
            else if (color)
            {
                _cubeModel.FlyColor(cube, speed);
            }
            else
            {
                _cubeModel.Fly(cube, speed);
            }
        }
    }
}