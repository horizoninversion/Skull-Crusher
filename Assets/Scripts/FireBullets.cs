using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int bulletsAmount = 1;
    private Vector2 bulletMoveDirection;


    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }
    private void Fire()
    {
        //float angleStep = (endAngle - 270f);
        //float angleStep =180f;
        float angle = 0f;
        

        for(int i = 0; i< bulletsAmount + 1; i++)
        {
        
            float bulDirX = transform.position.x + Mathf.Sin((angle*Mathf.PI)/ 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle*Mathf.PI)/ 180f); 
            
            Vector3 bulMoveVector = new Vector3(bulDirX,bulDirY,0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Z_shoot>().SetMoveDirection(bulDir);
                   
           // angle += angleStep;
            angle=90f;
            //GameObject.Destroy(bul);
        }
    }

}
