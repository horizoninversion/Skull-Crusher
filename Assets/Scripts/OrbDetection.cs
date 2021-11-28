using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OrbDetection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals ("Player"))
        {
            Debug.Log("Next Level");
            SceneManager.LoadScene("Loading");
        }
    }
}
