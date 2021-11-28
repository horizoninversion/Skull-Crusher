using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Weapon : MonoBehaviour
{
    public LineRenderer line;

    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shoot()
{
    RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position,firePoint.right);
    {
        if (hitInfo){
            PlayerController player =hitInfo.transform.GetComponent<PlayerController>();

            line.SetPosition(0,firePoint.position);
            line.SetPosition(1,hitInfo.point);

        } else{
            line.SetPosition(0,firePoint.position);
            line.SetPosition(1,firePoint.position + firePoint.right*100);
        }
    }
    line.enabled = true;

    yield return 0;

    line.enabled = false;
}
}