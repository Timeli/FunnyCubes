using UnityEngine;

namespace Services
{
    public class GameFactory : IGameFactory
    {
        private const string CubePath = "FunnyCube";

        public GameObject CreateCube()
        {
            GameObject prefab = Resources.Load<GameObject>(CubePath);
            return UnityEngine.GameObject.Instantiate(prefab);
        }
    }
}
