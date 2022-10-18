using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code
{
    public class CurtainLogic : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private UIView _view;

        public void Construct(UIView view)
        {
            _view = view;
        }

        private void Awake()
        {
            _button.onClick.AddListener(() => gameObject.SetActive(false));       
        }

        private void OnDisable()
        {
            _view.enabled = true;
        }

    }
}