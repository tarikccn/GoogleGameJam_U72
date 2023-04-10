using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] PlayerAnimationControl pac = new PlayerAnimationControl();

    [SerializeField] OfficeSoundScript oss = new OfficeSoundScript();

    [SerializeField] AudioSource footSound;
    


    public float soundDelay = 0.5f;
    public float timer = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        footSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        SoundControll();
    }

    void SoundControll()
    {
        
        if (pac.isMove)
        {
            if (!footSound.isPlaying)
            {
                footSound.Play();
                
            }
        }
        else
        {
            footSound.Stop();
        }

       
    }

    IEnumerator Wait(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            footSound.Play();
        }
    }

}
