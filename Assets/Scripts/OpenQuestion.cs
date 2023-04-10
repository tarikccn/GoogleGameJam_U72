using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenQuestion : MonoBehaviour
{
    [SerializeField] GameObject questionPanel;

    public QuestionsScript questionsScript = new QuestionsScript();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            questionPanel.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
       
        if (questionsScript.isTrueAnswer == true)
        {
            questionsScript.isTrueAnswer = false;
            this.gameObject.SetActive(false);
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            questionPanel.SetActive(false);
        }
    }
}
