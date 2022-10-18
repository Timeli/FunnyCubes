using UnityEngine;

namespace Cubes
{
    public class CubeModel : ICubeModel
    {
        private readonly ActionDecorator color;
        private readonly ActionDecorator random;
        private readonly ActionDecorator rotate;

        public CubeModel()
        {
            color = new ColorAction();
            random = new RandomAction();
            rotate = new RotateAction();
        }

        public Cube Fly(GameObject cubePrefab, float speed)
        {
            Cube cube = PrepareComponent(cubePrefab);
            cube.Rigidbody.AddForce(Vector3.forward * speed, ForceMode.Impulse);

            return cube;
        }

        public void FlyColor(GameObject cubePrefab, float speed) => 
            color.Do(Fly(cubePrefab, speed));

        public void FlyRandom(GameObject cubePrefab, float speed) => 
            random.Do(Fly(cubePrefab, speed));

        public void FlyEffect(GameObject cubePrefab, float speed) => 
            rotate.Do(Fly(cubePrefab, speed));

        public void FlyColorRandom(GameObject cubePrefab, float speed) => 
            color.Do(random.Do(Fly(cubePrefab, speed)));

        public void FlyRandomEffect(GameObject cubePrefab, float speed) =>
            random.Do(rotate.Do(Fly(cubePrefab, speed)));

        public void FlyColorEffect(GameObject cubePrefab, float speed) =>
            color.Do(rotate.Do(Fly(cubePrefab, speed)));

        public void FlyColorRandomEffect(GameObject cubePrefab, float speed) =>
            color.Do(random.Do(rotate.Do(Fly(cubePrefab, speed))));

        private Cube PrepareComponent(GameObject cubePrefab)
        {
            Cube cube = cubePrefab.GetComponent<Cube>();

            StopMove(cube);
            StopRotate(cube);
            cube.SetCommonColor();

            return cube;
        }

        private static void StopRotate(Cube cube)
        {
            cube.Rigidbody.angularVelocity = Vector3.zero;
            cube.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        private static void StopMove(Cube cube)
        {
            cube.Rigidbody.velocity = Vector3.zero;
            cube.transform.position = Vector3.zero;
        }
    }
}