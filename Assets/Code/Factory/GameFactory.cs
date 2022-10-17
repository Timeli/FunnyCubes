using System;
using UnityEngine;

namespace Services
{
    public class GameFactory : IGameFactory
    {
        private const string CubePath = "FunnyCube";
        private const string UIViewPath = "UI_elements";
        private const string WallPath = "Wall";

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
                case ObjectForCreate.Wall:
                    gameObj = CreateWall();
                    break;
            }
            return gameObj;
        }

        private GameObject CreateWall() =>
            UnityEngine.GameObject.Instantiate(LoadPrefab(WallPath));

        private GameObject CreateCube() =>
            UnityEngine.GameObject.Instantiate(LoadPrefab(CubePath));

        private GameObject CreateUIView() =>
            UnityEngine.GameObject.Instantiate(LoadPrefab(UIViewPath));

        private GameObject LoadPrefab(string path) =>
            Resources.Load<GameObject>(path);
    }

    public enum ObjectForCreate
    {
        Cube,
        UiView,
        Wall
    }
}
