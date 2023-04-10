using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoginManager : MonoBehaviour
{
    [SerializeField] GameObject aboutPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void AboutButton()
    {
        aboutPanel.SetActive(true);
    }

    public void CloseAboutButton()
    {
        aboutPanel.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
