using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DoorOpen : MonoBehaviour
{
    public Transform door;
    public float openAngle = -90f;
    public float closeAngle = -7f;
    public float smooth = 2f;
    [SerializeField] GameObject fButton;
    private bool isOpen = false;
    [SerializeField] int lockLimit;
    public DoorLockSystem dls = new DoorLockSystem();

    [SerializeField] AudioSource doorSound;

    [SerializeField] GameObject doorError;

    private void Awake()
    {
        doorSound.Stop();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fButton.SetActive(true);
            PushFButton();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fButton.SetActive(false);
        }
    }

    void Update()
    {
        
            if (isOpen)
            {
                Quaternion targetRotation = Quaternion.Euler(0, closeAngle, 0);
                door.rotation = Quaternion.Slerp(door.rotation, targetRotation, smooth * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
                door.rotation = Quaternion.Slerp(door.rotation, targetRotation, smooth * Time.deltaTime);
            }
    }

    public void PushFButton()
    {
        Debug.Log("dls : " + dls.lockScore + " this: " + lockLimit);
        if (Input.GetKey(KeyCode.F) && dls.lockScore >= lockLimit)
        {
            doorSound.Play();
            isOpen = !isOpen;
        }
        else if(Input.GetKey(KeyCode.F) && dls.lockScore <= lockLimit)
        {
            StartCoroutine(Wait());
            Debug.Log("Kapý aÇýlmadý");
        }
    }

    IEnumerator Wait()
    {
        doorError.SetActive(true);
        yield return new WaitForSeconds(1f);
        doorError.SetActive(false);
    }
}
