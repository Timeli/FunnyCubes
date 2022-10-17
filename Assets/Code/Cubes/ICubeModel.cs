using UnityEngine;

namespace Cubes
{
    public interface ICubeModel
    {
        void Fly(GameObject cube, float speed);
        void Fly(GameObject cubePrefab, float speed, bool color);
    }
}