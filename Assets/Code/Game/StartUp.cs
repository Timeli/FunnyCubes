using UnityEngine;

namespace Game
{
    public class StartUp : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
        }
    }
}