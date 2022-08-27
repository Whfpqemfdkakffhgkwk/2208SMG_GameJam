using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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

    [SerializeField]
    CanvasRootShaker canvasRootShaker;

    [SerializeField]
    Text nicknameText;

    bool ready;

    void Start()
    {
        RefreshNickname(false);
        nicknameText.text = RefreshNickname(false);

        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.20f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        // 원래 값과 똑같을 수 있으므로 강제 콜백 호출 보장
        OnBgmSliderChange(bgmSlider.value);
        OnSfxSliderChange(sfxSlider.value);

        bgmSource.PlayDelayed(0.5f);

        ready = true;
    }

    public static string RefreshNickname(bool force)
    {
        if (force)
        {
            PlayerPrefs.DeleteKey("Nickname");
        }
        
        PlayerPrefs.SetString("GUID", PlayerPrefs.GetString("GUID", Guid.NewGuid().ToString()));
        
        PlayerPrefs.SetString("Nickname", PlayerPrefs.GetString("Nickname", NicknameGenerator.New));

        var nickname = PlayerPrefs.GetString("Nickname");

        Debug.Log($"Nickname: {nickname}");
        
        PlayerPrefs.Save();

        return nickname;
    }

    public void StartGame()
    {
        SoundManager.Instance.PlayLandmass();
        
        canvasRootShaker.enabled = true;
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
