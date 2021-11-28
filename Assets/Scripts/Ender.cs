using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ender : MonoBehaviour
{
     void OnCollisionEnter2D(Collision2D col)
    {   
        if (col.gameObject.tag.Equals("Player"))
        {
            Sound.Playsound("hit");
            Debug.Log ("Game Over");
            Destroy(col.gameObject);
            SceneManager.LoadScene("GO");
        }
    }
}