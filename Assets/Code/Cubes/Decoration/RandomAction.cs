using UnityEngine;

namespace Cubes
{
    public class RandomAction : ActionDecorator
    {
        private const float YMax = 5.5f;
        private const float YMin = -0.5f; 
        
        private const float XMax = 2.3f;
        private const float XMin = -2.3f; 

        public override void Apply(Cube cube) => 
            cube.SetPosition(NextPosion());

        private Vector3 NextPosion()
        {
            float x = Random.Range(XMin, XMax);
            float y = Random.Range(YMin, YMax);

            return new Vector2(x, y);
        }
    }
}