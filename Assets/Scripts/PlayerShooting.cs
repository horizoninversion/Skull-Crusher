using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
     void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        Destroy (gameObject, 10f);

    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals ("Enemy") )
        {
             Patrol enemy = col.GetComponent<Patrol>();
             if(enemy != null)
             {
                enemy.TakeDamage(1);
                Sound.Playsound("hit");
                Debug.Log ("Enemy Hit");
                Destroy(gameObject);
             }
        }
        
        else if (col.gameObject.tag.Equals ("Wall"))
        {
            Destroy(gameObject);
        }

        else if(col.gameObject.tag.Equals("Enemy2"))
        {
            jump enemy = col.GetComponent<jump>();
             if(enemy != null)
             {
                enemy.jTakeDamage(1);
                Sound.Playsound("hit");
                Debug.Log ("Enemy Hit");
                Destroy(gameObject);
             }
        }
        else if(col.gameObject.tag.Equals("Zombie"))
        {
            FollowPath enemy = col.GetComponent<FollowPath> ();
            if(enemy != null)
             {
                enemy.TakeDamage(1);
                Sound.Playsound("hit");
                Debug.Log ("Enemy Hit");
                Destroy(gameObject);
             }
        }
         else  if (col.gameObject.tag.Equals ("EZ") )
        {
             Patrol enemy = col.GetComponent<Patrol>();
             if(enemy != null)
             {
                enemy.TakeDamage(1);
                Sound.Playsound("hit");
                Debug.Log ("Enemy Hit");
                Destroy(gameObject);
             }
        }

        else if(col.gameObject.tag.Equals("Boss"))
        {   
            Boss enemy = col.GetComponent<Boss> ();
            if(enemy != null )
             { 
                enemy.TakeDamage2(1);
                Sound.Playsound("hit");
                Debug.Log ("Enemy Hit");
                Destroy(gameObject);
             }
        }
    }
}