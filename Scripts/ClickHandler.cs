using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class ClickHandler : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        _audioSource.Play();
    }
}
