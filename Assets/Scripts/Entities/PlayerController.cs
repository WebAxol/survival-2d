using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rig;

    private bool dead;
    private float xInput;
    private bool jumpInput;

    public void Start(){
        dead = false;
    }

    public void SetDead(){
        animator.SetBool("isDead", dead = true);

        Destroy(rig);
        Destroy(this);
    }

    private bool IsGrounded()
    {
        return Mathf.Abs(rig.linearVelocityY) < 0.05f;
    }

    void Update()
    {
        if(dead) return;

        if (Keyboard.current.leftArrowKey.isPressed){
            xInput = -1f;
            spriteRenderer.flipX = true;
        }
        else if (Keyboard.current.rightArrowKey.isPressed){
            xInput = 1f;
            spriteRenderer.flipX = false;
        }
        else
            xInput = 0f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)            
            jumpInput = IsGrounded();

        Debug.Log(spriteRenderer.flipX);


        animator.SetBool("isWalking", Mathf.Abs(xInput) > 0.0f);
        animator.SetBool("isJumping", !IsGrounded());        
    }

    void FixedUpdate()
    {
        rig.linearVelocity = new Vector2(xInput * moveSpeed, rig.linearVelocity.y);

        if (jumpInput){    
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        jumpInput = false;
    }
}