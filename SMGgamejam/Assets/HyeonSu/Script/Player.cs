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
        Rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Jump();
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            JumpLimit = false;
        }
    }

    void Move()
    {
        if(MoveKey == false && Input.GetKeyDown(KeyCode.F))
        {
            Rb.velocity = new Vector2(0f, Rb.velocity.y);
            Rb.AddForce(Vector2.right * 100);
            MoveKey = true;
        }
        else if(MoveKey == true && Input.GetKeyDown(KeyCode.J))
        {
            Rb.velocity = new Vector2(0f, Rb.velocity.y);
            Rb.AddForce(Vector2.right * 100);
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
