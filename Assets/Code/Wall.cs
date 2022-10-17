using Cubes;
using UnityEngine;

namespace Assets.Code
{
    public class Wall : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Cube cube))
            {
                cube.gameObject.SetActive(false);
            }
        }
    }
}