using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Vector2 direction;

    public bool canJump = true;
    public CapsuleCollider collider;
    public Animator PlayerAnim;

    public float margeManoeuvreX;
    public float middleX;

    public float jumpForce;
    public float respawnTimer = 2;
    public Rigidbody rb;

    public bool canLose = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if (Input.GetTouch(0).tapCount == 2)
            {
                Jump();
            }
        }

        if(GameManager.instance.gameContinue == true)
        {
            canLose = false;
            respawnTimer -= Time.deltaTime;
            if(respawnTimer <= 0)
            {
                GameManager.instance.gameContinue = false;
                canLose = true;
            }

        }

        if (canJump == true)
        {
            PlayerAnim.SetBool("bIsJumping", false);
        }
        if (canJump == false)
        {
            PlayerAnim.SetBool("bIsJumping", true);
        }



        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 PlayerPos = Camera.main.WorldToScreenPoint(transform.position);
            direction = touch.position - PlayerPos;
            direction.Normalize();

            if (transform.position.x > middleX - margeManoeuvreX && transform.position.x < middleX + margeManoeuvreX) //si notre doigt va vers la gauche
            {
                transform.Translate(new Vector3(direction.x, 0, 0) * speed * Time.deltaTime, Space.World);
            }
        }

    }

    private void FixedUpdate()
    {
        if (rb.velocity.y >= 0)
        {
            Physics.gravity = new Vector3(0, -9.81F, 0);
        }
        else if (rb.velocity.y < 0)
        {
            Physics.gravity = new Vector3(0, -40, 0);
        }
    }
    public void Jump()
    {
        if (canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canJump = true;
        }
        if(collision.gameObject.tag == "Obstacle" && canLose)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}
