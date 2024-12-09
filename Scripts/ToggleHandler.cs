using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleHandler : MonoBehaviour
{
    private const string Master = nameof(Master);

    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private Button _button;   
    
    private float _minValue = -80f;
    private float _value;

    public bool IsClicked { get; private set; }

    private void Awake()
    {
        IsClicked = false;
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchState);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchState);
    }    

    private void SwitchState()
    {          
        if (!IsClicked && _audioMixerGroup.audioMixer.GetFloat(Master, out float value))
        {
            _value = value;
        }

        if (!IsClicked)
        {
            _audioMixerGroup.audioMixer.SetFloat(Master, _minValue);
            IsClicked = true;
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(Master, _value); 
            IsClicked = false;
        }
    }
}
