using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FirstMission : MonoBehaviour
{
    public DoorLockSystem dls = new DoorLockSystem();
    [SerializeField] GameObject fButton;
    [SerializeField] VideoPlayer videoPlayer;
    //ScreenGameObject
    [SerializeField] GameObject blackScreen;
    [SerializeField] GameObject videoScreen;
    private void OnTriggerEnter(Collider other)
    {
        fButton.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            blackScreen.SetActive(false);
            videoScreen.SetActive(true);
            videoPlayer.Play();
            dls.lockScore++;
            this.gameObject.SetActive(false);
            fButton.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fButton.SetActive(false);
    }

    
}
