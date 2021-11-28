using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ZombieCOL : MonoBehaviour
{
    
     void OnCollisionEnter2D(Collision2D  col)
    {
        
        if (col.gameObject.tag.Equals ("Player"))
        {
            Sound.Playsound("hit");
            Debug.Log ("Hit");
            Destroy (col.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
