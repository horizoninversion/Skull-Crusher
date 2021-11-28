using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public int maxHealth = 4;
    private int currentHealth;
    public Transform firePoint;
    private float timeBtwShots;
    public float  startTimeBtwShots;
    public GameObject bullets;
    public float rayDistance;
    private bool movingRight = true;
    public Transform groundDetection;
    public GameObject effect;
    public GameObject bloodSplash;
    public GameObject HealthBar;
    private RipplePostProcessor camRipple;

    public HealthBar healthBar;

     void Start()
    {
        timeBtwShots = startTimeBtwShots;
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down , rayDistance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0 , -180 , 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0 , 0 , 0);
                movingRight = true;
            } 
        }

        if(timeBtwShots <=0)
        {
            Instantiate(bullets, firePoint.position ,firePoint.rotation);
            timeBtwShots = startTimeBtwShots;
            Sound.Playsound("bullet");
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        Physics2D.IgnoreLayerCollision (8,11);
    }




    public void TakeDamage(int damage)
    {
        currentHealth-= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth<=0)
        {   
            HealthBar.SetActive(false);
            camRipple.RippleEffect();
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
