using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D playerRb;
    public Camera cam;

    Vector2 movement;

    Vector3 v3Pos;

    Vector3 moveDir;

    GameObject goPlayer;

    public float fAngle;

    private Rigidbody2D rb;

    public GameObject rbGO;

    private Animator anim;

    private bool isDashButtonDown;

    bool lookingRight;

    public bool canMove;

    void Awake() {
        anim = GetComponent<Animator>();
        goPlayer = this.gameObject;
        playerRb = goPlayer.GetComponent<Rigidbody2D>();
        rb = rbGO.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        moveDir = new Vector3(movement.x, movement.y).normalized;

        if(movement.y != 0 || movement.x != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        v3Pos = Input.mousePosition;
        v3Pos.z = (goPlayer.transform.position.z - Camera.main.transform.position.z);
        v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
        v3Pos = v3Pos - goPlayer.transform.position;
        fAngle = Mathf.Atan2 (v3Pos.y, v3Pos.x) * Mathf.Rad2Deg - 90f;
        if (fAngle < 0.0f) fAngle += 360.0f;
        rb.rotation = fAngle;
        if(fAngle >= 0 && fAngle <= 180)
        {
            if(lookingRight != true)
            {
                Flip();
            }
        }
        else if(fAngle > 180)
        {
            if(lookingRight != false)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        lookingRight = !lookingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
