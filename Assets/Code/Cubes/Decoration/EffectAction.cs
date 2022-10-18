using UnityEngine;

namespace Cubes
{
    public class RotateAction : ActionDecorator
    {
        private const int Modificator = 50;

        public override Cube Do(Cube cube)
        {
            var randomVector = new Vector3(Randomf(), Randomf(), Randomf());
            cube.Rigidbody.AddTorque(randomVector * Modificator);

            return cube;
        }

        private float Randomf() => Random.Range(-1, 1);
    }
}