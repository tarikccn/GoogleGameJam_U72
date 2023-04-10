using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    
    [SerializeField]
    private float rotationSpeed = 10f;
    private float horizontal;
    private float vertical;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
    }

    void CharacterMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2;
        }
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        if (vertical > 0 || vertical < 0)
        {
            transform.Rotate(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);
        }
        transform.position += transform.forward * vertical * speed * Time.deltaTime;
    }

     
}
