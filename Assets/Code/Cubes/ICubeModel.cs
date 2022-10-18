using UnityEngine;

namespace Cubes
{
    public interface ICubeModel
    {
        Cube Fly(GameObject cube, float speed);
        void FlyColor(GameObject cubePrefab, float speed);
        void FlyColorRandom(GameObject cubePrefab, float speed);
        void FlyRandom(GameObject cubePrefab, float speed);
    }
}