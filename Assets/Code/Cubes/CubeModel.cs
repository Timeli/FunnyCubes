using UnityEngine;

namespace Cubes
{
    public class CubeModel : ICubeModel
    {
        private readonly ActionDecorator _color;
        private readonly ActionDecorator _random;

        public CubeModel()
        {
            _color = new ColorAction();
            _random = new RandomAction();
        }

        public Cube Fly(GameObject cubePrefab, float speed)
        {
            Cube cube = PrepareComponent(cubePrefab);
            
            cube.Rigidbody.AddForce(Vector3.forward * speed, ForceMode.Impulse);

            return cube;
        }

        public void FlyColor(GameObject cubePrefab, float speed)
        {
            Cube cube = Fly(cubePrefab, speed);
            _color.Apply(cube);
        }

        public void FlyRandom(GameObject cubePrefab, float speed)
        {
            Cube cube = Fly(cubePrefab, speed);
            _random.Apply(cube);
        }

        public void FlyEffect(GameObject cubePrefab, float speed)
        {
            Cube cube = Fly(cubePrefab, speed);
            _random.Apply(cube);
        }

        public void FlyColorRandom(GameObject cubePrefab, float speed)
        {
            Cube cube = Fly(cubePrefab, speed);
            _random.Apply(cube);
            _color.Apply(cube);
        }

        private Cube PrepareComponent(GameObject cubePrefab)
        {
            Cube cube = cubePrefab.GetComponent<Cube>();

            cube.Rigidbody.velocity = Vector3.zero;
            cube.transform.position = Vector3.zero;
            cube.SetCommonColor();
            
            return cube;
        }
    }

    public class EffectAction : ActionDecorator
    {
        public override void Apply(Cube cube)
        {
            var randomVector = new Vector3(Random.value, Random.value, Random.value);
            cube.Rigidbody.AddTorque(randomVector);
        }
    }
}