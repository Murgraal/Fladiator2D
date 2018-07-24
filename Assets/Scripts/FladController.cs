using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FladController : MonoBehaviour {

    public Rigidbody2D rigid;
    public Animator anime;
    public float speed,jumpForce;
    public bool isPlayerOne;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update ()
    {
        DoAnimations();
	}
    private void FixedUpdate()
    {
        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Movement(Vector2.left);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Movement(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Movement(Vector2.left);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Movement(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.RightControl))
                Jump();
        }

    }
    void DoAnimations()
    {
        if (isPlayerOne)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                anime.SetTrigger("Jump");
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                anime.SetTrigger("Run");
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                anime.SetTrigger("Idle");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
                anime.SetTrigger("Jump");
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                anime.SetTrigger("Run");
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                anime.SetTrigger("Idle");
            }
                
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherrigid = collision.gameObject.GetComponent<Rigidbody2D>();
        if (otherrigid != null)
        {
            var velocity = -otherrigid.velocity;
            rigid.AddForce(velocity, ForceMode2D.Impulse);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Beer")
        {
            if (isPlayerOne)
                ManagerManager.player1won = true;
            else
                ManagerManager.player2won = true;
            Destroy(collision.gameObject);
        }
    }

    void Jump()
    {
        rigid.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    void Movement(Vector2 direction)
    {
        rigid.AddForce(direction * speed);
    }

}
