using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManController : MonoBehaviour
{
    public float speed = 1.0f;
    private Animator anim;
    [SerializeField] GameObject gameEndScreen;
    public float cooldown = 3f;
    private bool isCooldown = false;
    private bool isNearDog = false;
    public GameObject shield;
    private Rigidbody2D rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();    
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        
        if (Input.GetKeyDown(KeyCode.X) && !isCooldown && isNearDog)
        {
            anim.SetTrigger("attack");
            isCooldown = true;
            shield.SetActive(true);
            Invoke("ResetCooldown", cooldown);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingGround"))
        {
            transform.SetParent(other.gameObject.transform);
        }
        
        if (other.gameObject.CompareTag("Bird"))
        {
            speed = 0;
            anim.SetTrigger("died");
            Invoke("EndGame", 1);
            SceneManager.LoadSceneAsync("GameOver");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MovingGround"))
        {
            transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("deadzone"))
        {
            speed = 0;
            anim.SetTrigger("died");
            Invoke("EndGame", 1);
            SceneManager.LoadSceneAsync("GameOver");
        }
        
        if (other.gameObject.CompareTag("Dog"))
        {
            speed = 0;
            anim.SetBool("isWalking", false);
            isNearDog = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dog"))
        {
            anim.SetBool("isWalking", true);
            speed = 1.0f;
            isNearDog = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
    }
    
    private void EndGame()
    {
        gameEndScreen.SetActive(true);
        Time.timeScale = 0;
    }

    void ResetCooldown()
    {
        isCooldown = false;
        shield.SetActive(false);
    }
}