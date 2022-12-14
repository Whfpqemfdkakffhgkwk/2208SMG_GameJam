using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    [SerializeField]
    AudioClip buttonClick;

    [SerializeField]
    AudioClip boxOpening;

    [SerializeField]
    AudioClip boxOpened;
    
    [SerializeField]
    AudioClip goalIn;
    
    [SerializeField]
    AudioClip gameOver;

    [SerializeField]
    AudioClip landmass;

    [SerializeField]
    AudioClip boost;

    [SerializeField]
    AudioClip buff;
    
    [SerializeField]
    AudioClip debuff;

    [SerializeField]
    AudioSource sfxSource;

    void Awake()
    {
        Instance = this;
    }

    // 버튼 터치음
    public void PlayButtonClick() => sfxSource.PlayOneShot(buttonClick);
    
    // 개봉 진행 효과음
    public void PlayBoxOpening() => sfxSource.PlayOneShot(boxOpening);
    
    // 개봉 완료 효과음
    public void PlayBoxOpened() => sfxSource.PlayOneShot(boxOpened);
    
    // 골인 효과음
    public void PlayGoalIn() => sfxSource.PlayOneShot(goalIn);
    
    // 게임 오버 효과음
    public void PlayGameOver() => sfxSource.PlayOneShot(gameOver);
    
    // Splash에서 게임 시작 눌렀을 때 효과음
    public void PlayLandmass() => sfxSource.PlayOneShot(landmass);
    
    // 부스트 시작 시
    public void PlayBoost() => sfxSource.PlayOneShot(boost);
    
    // 버프 효과음
    public void PlayBuff() => sfxSource.PlayOneShot(buff);
    
    // 디버프 효과음
    public void PlayDebuff() => sfxSource.PlayOneShot(debuff);
}
