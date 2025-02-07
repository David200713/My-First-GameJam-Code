using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    [SerializeField]private float speed = 8f;
    [SerializeField]private float jumpPower = 16f;
    private bool isFacingRight;
    
    //bool jump = false;

    /*private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;*/

    public Animator anim;
    SfxPlayer audioManager;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask platformLayer; 
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SfxPlayer>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        /*if(isDashing)
        {
            return;
        }*/

        horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(horizontal));

        if(IsGrounded())
        {
            anim.SetBool("Fall", false);
            anim.SetBool("Jump", false);
        }

        /*if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }*/
        
        Jump();
        Flip();
    }

    private void FixedUpdate()
    {
        /*if(isDashing)
        {
            return;
        }*/

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsPlatform()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);
    }

    public bool canAttack()
    {
        return IsGrounded();
    }

    public bool canAttack2()
    {
        return IsPlatform();
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && (IsGrounded() || IsPlatform()))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //jump = true;
            anim.SetBool("Jump", true);
            audioManager.PlaySFX(audioManager.jump);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.7f);
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true); 
        }
        else if(IsPlatform() == true)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
    }

    private void Flip()
    {
        if(isFacingRight && horizontal > 0f || !isFacingRight && horizontal < 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);
            
            /*Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;*/
        }
    }

    /*private IEnumerator Dash()
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
    }*/
}
