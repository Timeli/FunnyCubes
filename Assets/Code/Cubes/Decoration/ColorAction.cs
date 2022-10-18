using UnityEngine;

namespace Cubes
{
    public class ColorAction : ActionDecorator
    {
        private readonly MaterialPropertyBlock _block;

        public ColorAction()
        {
            _block = new();
        }

        public override Cube Do(Cube cube)
        {
            _block.SetColor("_Color", NextColor());
            cube.SetColor(_block);
            
            return cube;
        }

        private Color NextColor() =>
            Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}