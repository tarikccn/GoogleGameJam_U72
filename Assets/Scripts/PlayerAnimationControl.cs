using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;

    private bool _isMove = false;

    public bool isMove
    {
        get { return _isMove; }
        set { _isMove = value; }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControllAnim();
    }
    
    void ControllAnim()
    {
        float verticalInput = Input.GetAxis("Vertical");
        bool isShiftPressed = Input.GetKey(KeyCode.LeftShift);

        if (verticalInput > 0)
        {
            if (isShiftPressed)
            {
                anim.SetFloat("Speed", 2); //run hýzý
            }
            else
            {
                anim.SetFloat("Speed", 1); //yürüme hýzý                
            }
            isMove = true;
        }
        else if(verticalInput < 0)
        {
            anim.SetFloat("Speed", -1); //backward animasyonu
            isMove = true;
        }
        else
        {
            anim.SetFloat("Speed", 0); //idle animasyonu
            isMove = false;
        }

    }
}
