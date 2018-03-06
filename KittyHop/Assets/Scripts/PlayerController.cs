using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// make the player move left to right
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("positive integer depicting character horizontal movement")]
    [Range(0,10)]
    public int horizontalSpeed = 5;
    public float jumpHeight = 4;
    public float doubleJumpDelay;
    public bool isGrounded;
    public Transform feet;
    public float feetWidth;
    public float feetHeight;
    public LayerMask whatIsGround;
    public Transform leftBulletSpawnPoint;
    public Transform rightBulletSpawnPoint;
    public GameObject leftBullet, rightBullet;
    public bool canShoot = false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private bool doubleJumpEnabled;
    private bool leftPressed, rightPressed;

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), 
                                          new Vector2(feetWidth, feetHeight), 
                                          360.0f, 
                                          whatIsGround);
        if(isGrounded)
            doubleJumpEnabled = false;

        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("doubleJumpEnabled", doubleJumpEnabled);

        float playerSpeed = Input.GetAxisRaw("Horizontal"); // value will be 1, -1, 0
        playerSpeed *= horizontalSpeed;
        if (playerSpeed != 0)
            MoveHorizontal(playerSpeed);
        else
            StopMoving();

        if (Input.GetButtonDown("Jump"))
            Jump();

        if(Input.GetButtonDown("Fire1") && canShoot)
            ShootBullet();

        if(leftPressed)
            MoveHorizontal(-horizontalSpeed);
        if(rightPressed)
            MoveHorizontal(horizontalSpeed);

        anim.SetFloat("horizontalSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("verticalSpeed", rb.velocity.y);

    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(feet.position, feetRadius);
        Gizmos.DrawWireCube(feet.position, new Vector3(feetWidth, feetHeight));
    }

    public void MoveHorizontal(float playerSpeed)
    {
        if (playerSpeed < 0)
            sr.flipX = true;
        else
            sr.flipX = false;
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
    }

    void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            anim.SetBool("isGrounded", false);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(-2 * Physics.gravity.y * rb.gravityScale * jumpHeight));
            Invoke("EnableDoubleJump", doubleJumpDelay);
        }

        if(doubleJumpEnabled && !isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt(-2 * Physics.gravity.y * rb.gravityScale * jumpHeight));
            doubleJumpEnabled = false;
        }
    }

    void EnableDoubleJump()
    {
        doubleJumpEnabled = true;
    }

    void ShootBullet()
    {
        if(sr.flipX)
            Instantiate(leftBullet, leftBulletSpawnPoint.position, Quaternion.identity);
        else
            Instantiate(rightBullet, rightBulletSpawnPoint.position, Quaternion.identity);

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        switch(collider.gameObject.tag)
        {
            case "Powerup_Bullet":
                canShoot = true;
                Invoke("DisableShooting", 5);
                Destroy(collider.gameObject);
                break;
            case "Water":
                SFXController.instance.ShowSplash(feet.position);

                // TODO inform gameController that level needs to restart
                break;
            default:
                break;
        }
    }

    void DisableShooting()
    {
        canShoot = false;
    }

    public void MobileMoveLeft()
    {
        leftPressed = true;

    }
    public void MobileMoveRight()
    {
        rightPressed = true;
    }
    public void MobileStop()
    {
        rightPressed = false;
        leftPressed = false;

        StopMoving();
    }

    public void MobileJump()
    {
        Jump();
    }
    public void MobileShootBullet()
    {
        if(canShoot)
            ShootBullet();
    }


}