using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code
{
    public class InitialLoad : MonoBehaviour
    {
        public void Start()
        {
            LoadLevel("One");
        }
        
        public void LoadLevel(string scene)
        {
            if (SceneManager.GetActiveScene().name == scene)
                return;

            AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        }
    }
}