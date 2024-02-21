using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIPlaySound : MonoBehaviour
{

    public AudioClip audioClip;

    private AudioSource audioSource;
    private Button button;

    void Awake()
    {
        audioSource = transform.GetOrAddCompoment<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
        audioSource.volume = 1.0f;

        button = transform.GetComponent<Button>();
        button.onClick.AddListener(OnPlaySound);
    }

    public void OnPlaySound()
    {
        if(!AudioUtils.IsSoundPause) audioSource.Play();
    }
}