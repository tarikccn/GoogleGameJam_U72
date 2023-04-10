using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DoorLockSystem : MonoBehaviour
{
    public GameObject[] allDoor;
    private int _lockScore = 0;
    [SerializeField] TMP_Text currentKeyCount;

    public int lockScore
    {
        get { return _lockScore; }
        set { _lockScore = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lockScore == 0)
        {

        }else if (lockScore == 1)
        {

        }
        currentKeyCount.SetText("Mevcut Anahtar: "+lockScore+"/7");
        Debug.Log("Kapý sýnýrý: " + lockScore);
    }

    void asd()
    {
        for (int i = 0; i < allDoor.Length; i++)
        {
            if(lockScore == i)
            {
                
            }
        }
    }
}
