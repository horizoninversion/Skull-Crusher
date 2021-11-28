using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum moveType{UseTransform,UsePhysics};
    public moveType moveTypes;
    public Transform[] pathPoints;
    public int currentPath =0;
    public float reachDistance = 5.0f;
    public float speed = 100f;

    public int maxHealth = 4;
    private int currentHealth;

    public GameObject effect;
    public GameObject bloodSplash;
    public GameObject HealthBar;
    private RipplePostProcessor camRipple;

    public HealthBar healthBar;

    Animator anim;    

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (moveTypes){
            case moveType.UseTransform:
            UseTransform();
            break;
            case moveType.UsePhysics:
            UsePhysics();
            break;
        }
        
    }
   

    void UseTransform(){
        Vector3 dir = pathPoints [currentPath].position - transform.position;
        Vector3 dirNorm = dir.normalized;
        //Rigidbody2D.GetComponent<Animator.Equals>();
        transform.Translate (dirNorm * (speed*Time.deltaTime));

        

        
        if(dir.magnitude <= reachDistance){
            
            currentPath++;
            

            if(currentPath >= pathPoints.Length){
                    currentPath = 0;
                }
            }       
        //}


    }

    void UsePhysics(){
        Vector3 dir = pathPoints [currentPath].position - transform.position;
        Vector3 dirNorm = dir.normalized;

        rb.velocity = new Vector2 (dirNorm.x * (speed*Time.deltaTime),rb.velocity.y);
        if(currentPath == 2){
            rb.freezeRotation = true;
            transform.eulerAngles = new Vector3(0 , 0 , -90);
            
            rb.AddForce(transform.forward*80 *Time.deltaTime);
            transform.Translate(Vector2.right * 5 *Time.deltaTime);
        }
        else if(currentPath == 3){
            transform.eulerAngles = new Vector3(0 , 0 , -180);
            
            rb.gravityScale = -3;
            rb.mass = 0;
            rb.freezeRotation = false;
            //rb.constraints = RigidbodyConstraints2D.None;
            //rb.isKinematic = true;
        }
        else if(currentPath == 4){
            rb.gravityScale = -1f;
            rb.mass = 1;
           transform.eulerAngles = new Vector3(0 , 0 , 90);
           rb.constraints = RigidbodyConstraints2D.None; 
           //transform.Translate(Vector2.down * 3 *Time.fixedDeltaTime);
           
           rb.AddForce(transform.forward*80 *Time.deltaTime);
            transform.Translate(Vector2.right * 5 *Time.deltaTime);
           
        }
        else if(currentPath == 0){
            
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints2D.None;
            transform.eulerAngles = new Vector3(0 , 0 , 0);
            rb.mass = 3;
            rb.gravityScale = 1;
            rb.AddForce(transform.right*3*Time.deltaTime);
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            //transform.Rotate(0,0,0);
            //rb.isKinematic = true;
            //rb.AddForce(transform.forward*80 *Time.deltaTime);
            //rb.velocity = transform.forward * 80*Time.deltaTime;
            
        }

        
        
        if(dir.magnitude <= reachDistance){
            ++currentPath;
            
            if(currentPath >= pathPoints.Length){
                currentPath = 0;
            }
        }
        
    }

void OnDrawGizmos()
    {
        if(pathPoints == null)
        return;
        foreach(Transform pathPoint in pathPoints) {
            if (pathPoint){
                Gizmos.DrawSphere(pathPoint.position,reachDistance);
            }
            }
        
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

