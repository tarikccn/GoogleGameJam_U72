using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecutrityCameraRotate : MonoBehaviour
{
    bool startNextRotation = true;
    public bool rotRight;
    public float yaw;
    public float secondsToRot;

    private void Start()
    {
        
    }

    
    
    IEnumerator Rotate(float yaw, float duration)
    {
        startNextRotation = false;
        Quaternion initialRotation = transform.rotation;

        float timer = 0f;

        while(timer < duration)
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * yaw, Vector3.forward);
            yield return null;
        }

        startNextRotation = true;
        rotRight = !rotRight;
    }

    private void Update()
    {
        if(startNextRotation && rotRight)
        {
            StartCoroutine(Rotate(yaw, secondsToRot));
        }else if(startNextRotation && !rotRight)
        {
            StartCoroutine(Rotate(-yaw, secondsToRot));
        }
    }

    
}
