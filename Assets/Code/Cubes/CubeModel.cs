using UnityEngine;

namespace Cubes
{
    public class CubeModel : ICubeModel
    {
        public void Fly(GameObject cubePrefab, float speed)
        {
            Cube cube = ComponentPrepare(cubePrefab);
            JustFly(cube, speed);
        }

        public void Fly(GameObject cubePrefab, float speed, bool color)
        {
            Cube cube = ComponentPrepare(cubePrefab);
            Debug.Log("Color Logic");
            JustFly(cube, speed);
        }

        private Cube ComponentPrepare(GameObject cube)
        {
            cube.transform.position = Vector3.zero;
            return cube.GetComponent<Cube>();
        }

        private void JustFly(Cube cube, float speed) => 
            cube.Rigidbody.AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }
}