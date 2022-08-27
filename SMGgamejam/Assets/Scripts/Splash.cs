using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash : MonoBehaviour
{
    [SerializeField]
    AudioMixer mixer;

    [SerializeField]
    Slider bgmSlider;
    
    [SerializeField]
    Slider sfxSlider;

    [SerializeField]
    AudioSource bgmSource;

    [SerializeField]
    SoundManager soundManager;

    bool ready;

    void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        bgmSource.PlayDelayed(0.5f);

        ready = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("HyeonTest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnBgmSliderChange(float v)
    {
        mixer.SetFloat("BGMVolume", Mathf.Log10(v) * 20);
        PlayerPrefs.SetFloat("BGMVolume", v);
    }
    
    public void OnSfxSliderChange(float v)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(v) * 20);
        PlayerPrefs.SetFloat("SFXVolume", v);

        if (ready)
        {
            soundManager.PlayButtonClick();
        }
    }

    public void SavePreferences()
    {
        PlayerPrefs.Save();
    }
}
