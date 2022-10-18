using UnityEngine;

namespace Cubes
{
    public class CubeModel : ICubeModel
    {
        private readonly ActionDecorator color;
        private readonly ActionDecorator random;
        private readonly ActionDecorator effect;

        public CubeModel()
        {
            color = new ColorAction();
            random = new RandomAction();
            effect = new EffectAction();
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
            effect.Do(Fly(cubePrefab, speed));

        public void FlyColorRandom(GameObject cubePrefab, float speed) => 
            color.Do(random.Do(Fly(cubePrefab, speed)));

        public void FlyRandomEffect(GameObject cubePrefab, float speed) =>
            random.Do(effect.Do(Fly(cubePrefab, speed)));

        public void FlyColorEffect(GameObject cubePrefab, float speed) =>
            color.Do(effect.Do(Fly(cubePrefab, speed)));

        public void FlyColorRandomEffect(GameObject cubePrefab, float speed) =>
            color.Do(random.Do(effect.Do(Fly(cubePrefab, speed))));

        private Cube PrepareComponent(GameObject cubePrefab)
        {
            Cube cube = cubePrefab.GetComponent<Cube>();

            cube.Rigidbody.velocity = Vector3.zero;
            cube.transform.position = Vector3.zero;
            cube.SetCommonColor();
            
            return cube;
        }
    }
}