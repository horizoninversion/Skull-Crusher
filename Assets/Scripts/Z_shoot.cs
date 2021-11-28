using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Z_shoot : MonoBehaviour
{
    BulletPool bl;
    private Vector2 moveDirection;
    private float moveSpeed;

    private void OnEnabled()
    {
        Invoke("Destroy",2f);
    }

    void Start()
    {
        moveSpeed = 20f;
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        OnEnabled();
        //Destroy();
        //Destroy(gameObject,2f);
        //BulletPool.bulletPoolInstance.GetBullet();
        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
         if (col.gameObject.tag.Equals ("Player"))
        {
           PlayerController player = col.GetComponent<PlayerController>();
             if(player != null)
             {
                player.TakeDamage1(1);
                Sound.Playsound("hit");
                Debug.Log ("Enemy Hit");
                //Destroy(gameObject);
             }
        }
        //Destroy(gameObject);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    
    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }


}
