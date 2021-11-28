using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
  
public float speed = 2.5f;

public float jumpRange = 5f;

public float jumpRange2 = 6f;
public float attackRange = 1.8f;
Transform Player;
Boss boss;
Rigidbody2D rb;
override public void OnStateEnter(Animator animator,AnimatorStateInfo stateInfo,int layerIndex)
{
    Player = GameObject.FindGameObjectWithTag("Player").transform;
    rb = animator.GetComponent<Rigidbody2D>();
    boss = animator.GetComponent<Boss>();
}


override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,int layerIndex)
{

    boss.LookAtPlayer();
    boss.shoot();
    Vector2 target = new Vector2(Player.position.x,rb.position.y);
    Vector2 newPos = Vector2.MoveTowards(rb.position,target,speed * Time.fixedDeltaTime);
    rb.MovePosition(newPos);

    if(Vector2.Distance(Player.position,rb.position) <= attackRange)
    {
        animator.SetTrigger("Attack");
    }

    if(Vector2.Distance(Player.position,rb.position) <= jumpRange && (Vector2.Distance(Player.position,rb.position) >= jumpRange2))
    {
        animator.SetTrigger("Jump");
        boss.B_Jump();
        
    
    }
}

override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    animator.ResetTrigger("Attack");
    animator.ResetTrigger("Jump");

}


}
