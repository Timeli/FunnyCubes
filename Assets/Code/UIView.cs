using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Update()
    {
        Debug.Log(_slider.value);
    }
}
