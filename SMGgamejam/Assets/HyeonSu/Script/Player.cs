using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    #region 이동관련
    private bool MoveKey; //F - false, J - True
    private bool JumpLimit;
    public int moveSpeed = 80;
    #endregion
    #region 상자깡관련
    private bool unboxing;
    private bool unboxingKey;
    private int unboxingProgress;
    public int unboxingProgressSpeed = 2;
    #endregion

    [SerializeField] Slider UnboxingProgressSlider;
    [SerializeField] GameObject Item;
    Rigidbody2D Rb;
    GameObject CollisionObj;
    private void Awake()
    {
        //PlayerPrefs.SetFloat("BestRecord", 130); 
        Instance = this;
        Rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (UnboxingProgressSlider != null)
        {
            UnboxingProgressSlider.value = unboxingProgress;
            if (unboxingProgress >= 80 && unboxing)
            {
                Destroy(CollisionObj);
                Instantiate(Item, new Vector2(transform.position.x + 2, transform.position.y + 1), transform.rotation);
                UnboxingProgressSlider.gameObject.SetActive(false);
                unboxing = false;
            }
        }
        if (!unboxing)
        {
            Move();
            Jump();
        }
        else
            Unboxing();
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
                collision.gameObject.GetComponent<Item>().ItemEffect();
                Destroy(collision.gameObject);
                break;
            case "Box":
                unboxingProgress = 0;
                unboxing = true;
                UnboxingProgressSlider.gameObject.SetActive(true);
                CollisionObj = collision.gameObject;
                break;
            case "Hole":
                Debug.Log("asd");
                Rb.velocity = new Vector2(0, 0);
                gameObject.transform.DOMoveY(transform.position.y - 5, 1);
                break;
        }
    }
    void Move()
    {
        if (MoveKey == false && Input.GetKeyDown(KeyCode.F))
        {
            Rb.velocity = new Vector2(0f, Rb.velocity.y);
            Rb.AddForce(Vector2.right * moveSpeed);
            MoveKey = true;
            SendMessage("Flip", SendMessageOptions.DontRequireReceiver);
        }
        else if (MoveKey == true && Input.GetKeyDown(KeyCode.J))
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
        if (unboxingKey == false && Input.GetKeyDown(KeyCode.F))
        {
            unboxingProgress += unboxingProgressSpeed;
            unboxingKey = true;
        }
        else if (unboxingKey == true && Input.GetKeyDown(KeyCode.J))
        {
            unboxingProgress += unboxingProgressSpeed;
            unboxingKey = false;
        }
    }
}
