using UnityEngine;

namespace Cubes
{
    [RequireComponent(typeof(Rigidbody))]
    public class Cube : MonoBehaviour 
    {
        public Rigidbody Rigidbody { get; private set; }
        public Renderer Renderer { get; private set; }

        private MaterialPropertyBlock _block;
        private Color _commonColor;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Renderer = GetComponent<Renderer>();
            _block = new MaterialPropertyBlock();

            _commonColor = Renderer.material.color;
            _block.SetColor("_Color", _commonColor);
        }

        public void SetCommonColor() => SetColor(_block);

        public void SetColor(MaterialPropertyBlock block) => 
            Renderer.SetPropertyBlock(block);

        public void SetPosition(Vector3 pos) => 
            transform.position = pos;
    }
}