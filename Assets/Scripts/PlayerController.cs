using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public int maxHealth = 4;
    private int currentHealth;

    public Transform playerFirePoint;
    public GameObject playerBullets;

    private Animator anim;

    public float moveSpeed;
    public float jumpForce;
    private float moveInput;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatisGround;
    public Joystick joystick;

    private bool allowFire = true;
    public float coolDown;
    public GameObject bloodSplash;

    public GameObject HealthBar;

    public GameObject effect;

    public HealthBar healthBar;

    //private GameObject[] numberOfEnemies;
    void Start()
    {
       rb = GetComponent<Rigidbody2D> ();
       anim = GetComponent<Animator>(); 
       
       currentHealth = maxHealth;
       healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = joystick.Horizontal;
        if(moveInput >= .2f)
        {
            rb.velocity = new Vector2(moveSpeed , rb.velocity.y);
        } else if(moveInput <= -.2f)
        {
            rb.velocity = new Vector2(-moveSpeed , rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2( 0f * moveSpeed , rb.velocity.y);
        }
        
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisGround); //(coordinates for circle, radius of circle, layer) ."Checks if a collider falls within a circular area."

        if(moveInput < -.2f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(moveInput > .2f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        float jump = joystick.Vertical;

        if(isGrounded == true && jump >= .5f)
        {
            Sound.Playsound("jump");
            rb.velocity = Vector2.up * jumpForce;
        }

        if(moveInput > .2f && rb.velocity.y ==0)
        {
            anim.SetBool("isRunning", true);
        }
        else if(moveInput <-.2f && rb.velocity.y == 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning",false);
        }

        if(rb.velocity.y == 0)
        {
            anim.SetBool("isJumping",false);
        }
        if(rb.velocity.y >0)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    //Firing
    if(CrossPlatformInputManager.GetButtonDown("Fire1") && (allowFire))
        {
            Debug.Log("Firing");
            Instantiate(playerBullets, playerFirePoint.position ,playerFirePoint.rotation);
            allowFire = false;
            StartCoroutine(coolDownFunc(coolDown));
        }


    }
    void OnCollisionEnter2D(Collision2D col)
    {   
        if (col.gameObject.tag.Equals("Enemy"))
        {
                
            Debug.Log ("Game Over");
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            //Sound.Playsound("Game Over");
            Destroy(gameObject);
            
            SceneManager.LoadScene("GameOver");
            
        }
        else if(col.gameObject.tag.Equals("Enemy2"))
        {
            Debug.Log ("Game Over");
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            //Sound.Playsound("Game Over");
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }

        else if(col.gameObject.tag.Equals("Zombie"))
        {
            Debug.Log ("Game Over");
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            //Sound.Playsound("Game Over");
            Destroy(gameObject);
            SceneManager.LoadScene("GO"); 
        }
         else if(col.gameObject.tag.Equals("EZ"))
        {
            Debug.Log ("Game Over");
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            //Sound.Playsound("Game Over");
            Destroy(gameObject);
            SceneManager.LoadScene("GO"); 
        }
        else if(col.gameObject.tag.Equals("Boss"))
        {
            Debug.Log ("Game Over");
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            //Sound.Playsound("Game Over");
            Destroy(gameObject);
            SceneManager.LoadScene("GO"); 
        }
        
    }


    public void TakeDamage(int damage)
    {
        currentHealth-= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth<=0)
        {   
            HealthBar.SetActive(false);
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
     public void TakeDamage1(int damage)
    {
        currentHealth-= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth<=0)
        {   
            HealthBar.SetActive(false);
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene("GO");
        }
    }
    IEnumerator coolDownFunc(float secs)
    {
        yield return new WaitForSeconds(secs);
        allowFire = true;
    }
}
