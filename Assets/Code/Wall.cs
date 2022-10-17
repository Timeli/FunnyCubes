using Cubes;
using UI;
using UnityEngine;

namespace Assets.Code
{
    public class Wall : MonoBehaviour
    {
        public void Construct(UIView view)
        {
            view.DistanceChanged += ChangePosition;
        }

        private void ChangePosition(float distance) => 
            transform.position = transform.forward * distance;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Cube cube))
            {
                cube.gameObject.SetActive(false);
            }
        }
    }
}