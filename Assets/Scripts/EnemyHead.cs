using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{

    public GameObject effect;
    public GameObject bloodSplash;
    private RipplePostProcessor camRipple;

void Start()
{
    camRipple = Camera.main.GetComponent<RipplePostProcessor>();
}
void OnTriggerEnter2D(Collider2D col)
{
    if(col.gameObject.tag==("Player"))
    {
        camRipple.RippleEffect();
        Instantiate(bloodSplash, transform.position, Quaternion.identity);
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
}
