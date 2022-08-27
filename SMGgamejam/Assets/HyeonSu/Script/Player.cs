using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    #region 이동관련
    private bool MoveKey; //F - false, J - True
    private bool JumpLimit;
    public int moveSpeed = 100;
    #endregion
    #region 상자깡관련
    private bool unboxing;
    private bool unboxingKey;
    private int unboxingProgress;
    public int unboxingProgressSpeed = 2;
    #endregion
    public bool boost;

    [SerializeField] Slider UnboxingProgressSlider;
    [SerializeField] GameObject Item;

    [SerializeField]
    AudioMixer mixer;
    
    Rigidbody2D Rb;
    GameObject CollisionObj;

    private void Awake()
    {
        Instance = this;
        Rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        var bgmVol = PlayerPrefs.GetFloat("BGMVolume", 0.20f);
        mixer.SetFloat("BGMVolume", Mathf.Log10(bgmVol) * 20);
        
        var sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        mixer.SetFloat("SFXVolume", Mathf.Log10(sfxVol) * 20);    
    }
    
    private void Update()
    {
        if (UnboxingProgressSlider != null)
        {
            UnboxingSliderUpdate();
        }
        if (!unboxing && !boost)
        {
            Move();
            Jump();
        }
        else
        {
            Unboxing();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":
                JumpLimit = false;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "DropJudgment":
                GameManager.Instance.GameOver();
                break;
            case "Goal":
                GameManager.Instance.GameClear();
                break;
            case "Item":
                ItemEffect(collision.gameObject.GetComponent<Item>().ItemCase);
                Destroy(collision.gameObject);
                break;
            case "Box":
                if (!boost)
                {
                    unboxingProgress = 0;
                    unboxing = true;
                    UnboxingProgressSlider.gameObject.SetActive(true);
                    CollisionObj = collision.gameObject;
                }
                break;
            case "Hole":
                if (!boost)
                {
                    Rb.velocity = new Vector2(0, 0);
                    gameObject.transform.DOMoveY(transform.position.y - 5, 1);
                }
                break;
        }
    }
    void UnboxingSliderUpdate()
    {
        UnboxingProgressSlider.value = unboxingProgress;
        if (unboxingProgress >= 80 && unboxing)
        {
            Destroy(CollisionObj);
            Instantiate(Item, new Vector2(transform.position.x + 2, transform.position.y + 3), transform.rotation);
            UnboxingProgressSlider.gameObject.SetActive(false);
            SoundManager.Instance.PlayBoxOpened();
            unboxing = false;
        }
    }
    void Move()
    {
        if (MoveKey == false && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            Rb.velocity = new Vector2(0f, Rb.velocity.y);
            Rb.AddForce(Vector2.right * moveSpeed);
            MoveKey = true;
            SendMessage("Flip", SendMessageOptions.DontRequireReceiver);
        }
        else if (MoveKey == true && (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            Rb.velocity = new Vector2(0f, Rb.velocity.y);
            Rb.AddForce(Vector2.right * moveSpeed);
            MoveKey = false;
            SendMessage("Flip", SendMessageOptions.DontRequireReceiver);
        }
    }
    void Jump()
    {
        if (!JumpLimit && Input.GetKeyDown(KeyCode.Space))
        {
            JumpLimit = true;
            Rb.AddForce(Vector2.up * 400);
        }
    }
    void Unboxing()
    {
        if (unboxingKey == false && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            unboxingProgress += unboxingProgressSpeed;
            unboxingKey = true;

            if (boost == false)
            {
                SoundManager.Instance.PlayBoxOpening();
            }
        }
        else if (unboxingKey == true && (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            unboxingProgress += unboxingProgressSpeed;
            unboxingKey = false;

            if (boost == false)
            {
                SoundManager.Instance.PlayBoxOpening();
            }
        }
    }
    public void ItemEffect(int ItemCase)
    {
        switch (ItemCase)
        {
            case 1:
                StartCoroutine(GameManager.Instance.SpeedUp());
                Debug.Log(ItemCase);
                break;
            case 2:
                StartCoroutine(GameManager.Instance.SpeedDown());
                Debug.Log(ItemCase);
                break;
            case 3:
                StartCoroutine(GameManager.Instance.UnboxingSpeedUp());
                Debug.Log(ItemCase);
                break;
            case 4:
                StartCoroutine(GameManager.Instance.UnboxingSpeedDown());
                Debug.Log(ItemCase);
                break;
            case 5:
                StartCoroutine(GameManager.Instance.BoostOn());
                Debug.Log(ItemCase);
                break;
        }
    }
}
