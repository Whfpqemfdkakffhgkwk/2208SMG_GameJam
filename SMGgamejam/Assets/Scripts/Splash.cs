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

    [SerializeField]
    GameObject[] dummyList;

    [SerializeField]
    Transform dummyParent;

    [SerializeField]
    DummyPlayerGenerator dummyPlayerGenerator;

    [SerializeField]
    GraphicRaycaster graphicRaycaster;

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
        graphicRaycaster.enabled = false;
        dummyPlayerGenerator.EnableGroup();
    }

    public void QuitGame()
    {
        ConfirmPopup.Instance.Open("정말로 종료하시겠습니까?", () =>
        {
            Application.Quit();    
        }, () =>
        {
            ConfirmPopup.Instance.Close();
        });
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

    public void InstantiateSplashDummy()
    {
        Destroy(Instantiate(dummyList[Random.Range(0, dummyList.Length - 1)], dummyParent, false), 2);
        Destroy(Instantiate(dummyList[Random.Range(0, dummyList.Length - 1)], dummyParent, false), 2);
    }
}
