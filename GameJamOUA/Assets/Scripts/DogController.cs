using UnityEngine;
using UnityEngine.SceneManagement;

public class DogController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform cameraTransform;
    public float smoothing = 5f;
    private Animator anim;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isSlopingGround;
    private Vector3 offset;
    private Rigidbody2D rb;
    [SerializeField] GameObject gameEndScreen;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        rb.centerOfMass = new Vector2(rb.centerOfMass.x, rb.centerOfMass.y - 0.02f);
        offset = cameraTransform.position - transform.position;
        isFacingRight = true;
    }

    private void Update()
    {
        var moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0) anim.SetBool("isRunning", true);
        else anim.SetBool("isRunning", false);

        if (moveInput < 0)
        {
            if (isSlopingGround || !isGrounded)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180,
                    isFacingRight ? -transform.eulerAngles.z : transform.eulerAngles.z);
            else if (!isSlopingGround) transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, 0);

            isFacingRight = false;
        }
        else if (moveInput > 0)
        {
            if (isSlopingGround || !isGrounded)
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0,
                    !isFacingRight ? -transform.eulerAngles.z : transform.eulerAngles.z);
            else if (!isSlopingGround) transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);

            isFacingRight = true;
        }

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && (isGrounded || isSlopingGround))
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private void LateUpdate()
    {
        var targetCamPos = transform.position + offset;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, targetCamPos, smoothing * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        if (collision.collider.CompareTag("SlopingGround"))
        {
            isGrounded = true;
            rb.freezeRotation = false;
            isSlopingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = false;

        if (collision.collider.CompareTag("SlopingGround"))
        {
            isGrounded = false;
            rb.freezeRotation = true;
            isSlopingGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            speed = 0;
            anim.SetTrigger("died");
            Invoke("EndGame", 1);
            SceneManager.LoadSceneAsync("GameOver");
        }
    }
    
    private void EndGame()
    {
        gameEndScreen.SetActive(true);
        Time.timeScale = 0;
    }
}