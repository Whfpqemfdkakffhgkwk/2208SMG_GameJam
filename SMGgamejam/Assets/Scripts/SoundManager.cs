using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioClip buttonClick;

    [SerializeField]
    AudioSource sfxSource;

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClick);
    }
}
