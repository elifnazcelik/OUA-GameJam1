using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingPlatform : MonoBehaviour
{
    public float swingSpeed = 1f;
    public float swingAngle = 30f;

    private float startAngle;
    private bool isSwinging = true;

    void Start()
    {
        // Baþlangýç açýsýný kaydet
        startAngle = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        if (isSwinging)
        {
            float angle = startAngle + swingAngle * Mathf.Sin(Time.time * swingSpeed);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    public void StopSwinging()
    {
        isSwinging = false;
    }


}
