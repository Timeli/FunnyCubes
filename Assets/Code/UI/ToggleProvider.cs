using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleProvider : MonoBehaviour
{
    [SerializeField] private Toggle _color;
    [SerializeField] private Toggle _random;
    [SerializeField] private Toggle _effects;

    public Action<bool> OnColorChanged;
    public Action<bool> OnRandomChanged;
    public Action<bool> OnEffectsChanged;

    private void Start()
    {
        _color.onValueChanged.AddListener(ColorToggleChange);
        _random.onValueChanged.AddListener(RandomToggleChange);
        _effects.onValueChanged.AddListener(EffectToggleChange);
    }
    private void OnDestroy()
    {
        _color.onValueChanged.RemoveListener(ColorToggleChange);
        _random.onValueChanged.RemoveListener(RandomToggleChange);
        _effects.onValueChanged.RemoveListener(EffectToggleChange);
    }

    private void EffectToggleChange(bool value) => 
        OnEffectsChanged?.Invoke(value);

    private void RandomToggleChange(bool value) => 
        OnRandomChanged?.Invoke(value);

    private void ColorToggleChange(bool value) => 
        OnColorChanged?.Invoke(value);
}
