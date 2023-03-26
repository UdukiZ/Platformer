using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterController2D : MonoBehaviour
{   private float horizontal;
    public float speed = 3f;
    public float jumpingPower = 6f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool doubleJump = false;
    private bool isDashing;
    public float dashingPower = 12f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = .5f;

    private bool jumpKey = false;
    private bool dashKey = false;
    public GameObject Canvas;
    private playerAnimation _playerAnim;

    public static string[] tutorialText = new string[2]
        {
            "You may now press space twice to Doublejump",
            "You may now press shift to Dash",
        };

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        _playerAnim = this.GetComponent<playerAnimation>();
        Canvas.SetActive(false);
    }
    
    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        _playerAnim.playerSpeed(horizontal);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {   rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJump = true;

        } else if (Input.GetButtonDown("Jump") && doubleJump == true && jumpKey == true){
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            doubleJump = false;

        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                   
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && dashKey == true)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision){
    Debug.Log("ah");
   
    if(collision.gameObject.tag == "DJ")
     {
        Object.Destroy(collision.gameObject);
        jumpKey = true;
        Canvas.SetActive(true);
        Canvas.GetComponentInChildren<TextMeshProUGUI>().text = tutorialText[0];
     }
     if(collision.gameObject.tag == "Dash")
     {
        Object.Destroy(collision.gameObject);
        dashKey = true;
        Canvas.SetActive(true);
        Canvas.GetComponentInChildren<TextMeshProUGUI>().text = tutorialText[1];
     }
    }
}