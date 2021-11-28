using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss : MonoBehaviour
{

private float timeBtwShots;
public float  startTimeBtwShots = 0f;
public int health = 100;
public Transform firePoint;
public GameObject laserPrefab;
public float speed;
public Transform groundDetection;
//private bool movingRight = true;
public float checkRadius;
private bool isGrounded;
public Transform feetPos;
public float jumpTime;
public Transform Player;
public bool isFlipped = false;

public int maxHealth = 4;
public int CH=4;

private Animator anim;

public GameObject effect;
public GameObject bloodSplash;
public GameObject HealthBar;
private RipplePostProcessor camRipple;

public HealthBar healthBar;

void start()
{
    timeBtwShots = startTimeBtwShots;

    camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        
    //CH = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
}


public void LookAtPlayer()
{
    Vector3 flipped = transform.localScale;
    flipped.z *= -1f;

    if (transform.position.x > Player.position.x && !isFlipped)
    {
        transform.localScale = flipped;
        transform.Rotate(0f,180f,0f);
        isFlipped = true;
    }
    else if (transform.position.x < Player.position.x && isFlipped)
    {
        transform.localScale = flipped;
        transform.Rotate(0f,180f,0f);
        isFlipped = false;
    }

}
public void B_Jump()
{
    
    isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius);
        if(isGrounded == true){
            transform.Translate(Vector2.up *jumpTime* Time.deltaTime);
            //anim.SetTrigger("Jump");
            transform.Translate(Vector2.right * speed * Time.deltaTime);
}
}
public void shoot()
{
   if(timeBtwShots <=0)
        {
            Instantiate(laserPrefab, firePoint.position ,firePoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
}


 public void TakeDamage2(int damage)
    {   Debug.Log(CH);
        CH-= damage;
        healthBar.SetHealth(CH);
        
        if(CH<=0)
        {   
            HealthBar.SetActive(false);
            //camRipple.RippleEffect();
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
             SceneManager.LoadScene("End");
        }
    }
}