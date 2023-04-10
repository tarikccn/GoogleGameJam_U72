using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAtilHcm : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("tr");
        }
    }
}
