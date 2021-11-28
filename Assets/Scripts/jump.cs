using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float speed;
    private Animator anim;
    public Transform groundDetection;
    private bool movingRight = true;
    public float checkRadius;
    private bool isGrounded;
    public Transform feetPos;
    public float jumpTime;
    private Rigidbody2D rb;
    public int maxHealth = 1;
    private int currentHealth;
    public GameObject effect;

    public GameObject bloodSplash;

    public GameObject HealthBar;
    private RipplePostProcessor camRipple;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position,checkRadius);
        if(isGrounded == true){
            transform.Translate(Vector2.up *jumpTime* Time.deltaTime);
            //rb.velocity = Vector2.up * jumpTime;
            //RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down);
            RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position,Vector2.right);
            RaycastHit2D wallInfoL = Physics2D.Raycast(groundDetection.position,Vector2.left);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        
        if(wallInfo.collider == false || wallInfoL.collider == false)
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
         }

        if(rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
        }

        if(rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }       
        
    }


public void jTakeDamage(int damage)
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
