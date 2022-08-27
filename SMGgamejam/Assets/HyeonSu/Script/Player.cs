using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool MoveKey; //F - false, J - True
    private bool JumpLimit;
    Rigidbody2D Rb;
    private void Awake()
    {
        //PlayerPrefs.SetFloat("BestRecord", 130); 최고기록 초기화 입니다
        Rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Jump();
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
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
        }
    }
    void Move()
    {
        if(MoveKey == false && Input.GetKeyDown(KeyCode.F))
        {
            Rb.velocity = new Vector2(0f, Rb.velocity.y);
            Rb.AddForce(Vector2.right * 80);
            MoveKey = true;
        }
        else if(MoveKey == true && Input.GetKeyDown(KeyCode.J))
        {
            Rb.velocity = new Vector2(0f, Rb.velocity.y);
            Rb.AddForce(Vector2.right * 80);
            MoveKey = false;
        }
    }
    void Jump()
    {
        if(!JumpLimit && Input.GetKeyDown(KeyCode.Space))
        {
            JumpLimit = true;
            Rb.AddForce(Vector2.up * 400);
        }
    }
}
