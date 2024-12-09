using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _soundsSlider;
    [SerializeField] private Slider _backgroundMusicSlider;
    
    private float _mixerMinVolume = -80f;

    private int _volumeStep = 20;

    private bool _isMasterDisabled;

    private const string Master = nameof(Master);
    private const string Sounds = nameof(Sounds);
    private const string BackgroundMusic = nameof(BackgroundMusic);

    private void Awake()
    {
        _audioMixer.SetFloat(Master, _mixerMinVolume);
        _audioMixer.SetFloat(Sounds, _mixerMinVolume);
        _audioMixer.SetFloat(BackgroundMusic, _mixerMinVolume);
    }

    public void ToggleMusic()
    {
        if (_audioMixer.GetFloat(Master, out float value))
        {
            if (value != _mixerMinVolume)
            {
                _isMasterDisabled = true;
                _audioMixer.SetFloat(Master, _mixerMinVolume);
                
            }
            else
            {
                _isMasterDisabled = false;
                ChangeMasterVolume();                
            }
        }        
    }

    public void ChangeMasterVolume()
    {
        if (!_isMasterDisabled)
            _audioMixer.SetFloat(Master, Mathf.Log10(_masterSlider.value) * _volumeStep);

    }

    public void ChangeSoundsVolume()
    {
        if (!_isMasterDisabled)
            _audioMixer.SetFloat(Sounds, Mathf.Log10(_soundsSlider.value) * _volumeStep);
    }
    
    public void ChangeBackgroundVolume()
    {
        if (!_isMasterDisabled)
            _audioMixer.SetFloat(BackgroundMusic, Mathf.Log10(_backgroundMusicSlider.value) * _volumeStep);
    }
}
