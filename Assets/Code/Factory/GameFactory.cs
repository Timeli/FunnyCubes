using UnityEngine;

namespace Services
{
    public class GameFactory : IGameFactory
    {
        private const string CubePath = "FunnyCube";
        private const string UIViewPath = "UI_elements";

        public GameObject Create(ObjectForCreate obj)
        {
            GameObject gameObj = null;
            switch (obj)
            {
                case ObjectForCreate.Cube:
                    gameObj = CreateCube();
                    break;
                case ObjectForCreate.UiView:
                    gameObj = CreateUIView();
                    break;
            }
            return gameObj;
        }

        private GameObject CreateCube()
        {
            return UnityEngine.GameObject.Instantiate(LoadPrefab(CubePath));
        }

        private GameObject CreateUIView()
        {
            return UnityEngine.GameObject.Instantiate(LoadPrefab(UIViewPath));
        }

        private GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }
    }

    public enum ObjectForCreate
    {
        Cube,
        UiView,
    }
}
