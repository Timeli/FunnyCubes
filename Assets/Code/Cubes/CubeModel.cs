using UnityEngine;

namespace Cubes
{
    public class CubeModel : ICubeModel
    {
        public void Fly(GameObject cube, float speed)
        {
            Cube c = cube.GetComponent<Cube>();
            c.Rigidbody.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        }
    }
}