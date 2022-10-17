using UnityEngine;

namespace Cubes
{
    [RequireComponent(typeof(Rigidbody))]
    public class Cube : MonoBehaviour 
    {
        public Rigidbody Rigidbody { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}