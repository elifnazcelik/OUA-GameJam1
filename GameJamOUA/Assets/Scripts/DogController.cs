using UnityEngine;

public class DogController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private bool isSlopingGround;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var moveInput = Input.GetAxis("Horizontal");
        
        if (moveInput != 0) anim.SetBool("isRunning", true);
        else anim.SetBool("isRunning", false);
        
        if (moveInput < 0) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (moveInput > 0) transform.eulerAngles = new Vector3(0, 0, 0);
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded) rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        
        if (isSlopingGround) 
        {
            if (Input.GetKeyDown(KeyCode.D))
                transform.Rotate(0,0,45);
            if (Input.GetKeyDown(KeyCode.A))
                transform.Rotate(0,0,-45);
            //if (moveInput < 0) transform.eulerAngles = new Vector3(0, 180, 0);
            //else if (moveInput > 0) transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = true;
        if (collision.collider.CompareTag("SlopingGround")) isSlopingGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = false;
    }

    
}