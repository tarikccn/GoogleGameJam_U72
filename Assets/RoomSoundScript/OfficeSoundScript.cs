using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeSoundScript : MonoBehaviour
{

    [SerializeField] AudioSource scarySound;

    private void Awake()
    {
        scarySound.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scarySound.Play();
        }
        
    }

    
}
