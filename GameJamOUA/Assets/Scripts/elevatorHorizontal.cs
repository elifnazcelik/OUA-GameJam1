using UnityEngine;

public class ElevatorHorizontal : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float speed = 2.0f;
    private bool movingRight = true;
    private float waitCounter;
    private readonly float waitTime = 2.0f;

    private void Start()
    {
        transform.position = leftPoint.position;
        waitCounter = waitTime;
    }

    private void Update()
    {
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPoint.position, speed * Time.deltaTime);
            if (transform.position == rightPoint.position)
            {
                if (waitCounter <= 0)
                {
                    movingRight = false;
                    waitCounter = waitTime;
                }
                else
                {
                    waitCounter -= Time.deltaTime;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPoint.position, speed * Time.deltaTime);
            if (transform.position == leftPoint.position)
            {
                if (waitCounter <= 0)
                {
                    movingRight = true;
                    waitCounter = waitTime;
                }
                else
                {
                    waitCounter -= Time.deltaTime;
                }
            }
        }
    }
}