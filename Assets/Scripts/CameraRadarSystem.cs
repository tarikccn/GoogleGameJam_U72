using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRadarSystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Alarm Active");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Alarm DeActive");
        }

    }
}
