using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AIShooting : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
    public GameObject effect;
    public GameObject bloodSplash;
     void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy (gameObject, 10f);

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        
        if (col.gameObject.tag.Equals ("Player"))
        {
           PlayerController player = col.GetComponent<PlayerController>();
             if(player != null)
             {
                player.TakeDamage(1);
                Sound.Playsound("hit");
                Debug.Log ("Enemy Hit");
                Destroy(gameObject);
             }
        }
        if (col.gameObject.tag.Equals ("Wall"))
        {
             Destroy(gameObject);
        }
    }
}
