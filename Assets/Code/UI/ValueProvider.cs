using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ValueProvider : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _time;
        [SerializeField] private TMP_InputField _speed;


        private void Start()
        {
            _time.onValueChanged.AddListener(Print);
        }

        private void Print(string text)
        {
            if (float.TryParse(text, out float time))
            {

            }
        }
    }
}