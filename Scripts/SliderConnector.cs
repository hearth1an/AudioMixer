using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class SliderConnector : MonoBehaviour
{ 
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private ToggleHandler _toggleHandler;

    private Slider _slider;

    private float _minValue = 0.001f;
    private float _maxValue = 1f;

    private float _multiplyer = 20f;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        
        _slider.maxValue = _maxValue;
        _slider.minValue = _minValue;
        _slider.value = _maxValue;
    }

    private void OnEnable()
    {        
        _slider.onValueChanged.AddListener(SetVolume);        
    }

    private void OnDisable()
    {       
        _slider.onValueChanged.RemoveListener(SetVolume);        
    }

    public void SetVolume(float value)
    {    
        if (!_toggleHandler.IsClicked)
            _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroup.name, Mathf.Log10(value) * _multiplyer);
    } 

}
