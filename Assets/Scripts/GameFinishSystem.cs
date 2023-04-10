using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishSystem : MonoBehaviour
{

    [SerializeField] GameObject finishScreen;
    [SerializeField] AudioSource eminSes;
    [SerializeField] AudioSource scsound;
    private void Awake()
    {
        finishScreen.SetActive(false);
        eminSes.Stop();
        scsound.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Wait());
        }

        

    }


    IEnumerator Wait()
    {
        
        finishScreen.SetActive(true);
        scsound.Stop();
        eminSes.Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("FinishScene");
    }
}
