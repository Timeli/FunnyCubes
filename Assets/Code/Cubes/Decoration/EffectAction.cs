using UnityEngine;

namespace Cubes
{
    public class EffectAction : ActionDecorator
    {
        public override Cube Do(Cube cube)
        {
            var randomVector = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            cube.Rigidbody.AddTorque(randomVector * 50);

            return cube;
        }

    }
}