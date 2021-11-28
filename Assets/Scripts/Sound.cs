using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip hit,jump,bullet,GameOver;
    static AudioSource audioSource;

    void Start()
    {
        hit=Resources.Load<AudioClip>("hit");
        bullet=Resources.Load<AudioClip>("bullet");
        jump=Resources.Load<AudioClip>("jump");
        GameOver=Resources.Load<AudioClip>("GameOver");
        audioSource = GetComponent<AudioSource>();
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Playsound(string clip){

        switch(clip){
            case "bullet":
                audioSource.PlayOneShot(bullet);
                break;
             case "jump":
                audioSource.PlayOneShot(jump);
                break;
             case "hit":
                audioSource.PlayOneShot(hit);
                break;
            case "GameOver":
                audioSource.PlayOneShot(GameOver);
                break;
        }
    }
}
