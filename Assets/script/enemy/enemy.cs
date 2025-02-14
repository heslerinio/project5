using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float radius;
    public LayerMask player;
    private Transform pplayer;
    private Vector2 PlayerPos;
    public float speed;
    public float JumpPower;
    public Transform groundcheck;
    public LayerMask groundlayer;
    public SpriteRenderer spriterenderer;
    public Animator animator;
    private bool Stuned = false;
    public Transform pos;
  
    public float Attackradius = 0.5f;
    public float Damage = 20;
    public float AttackCooldown = 1;

    public float SetAttackDlay = 0.2f;

    public float AttackRangeX = 0.4f;
    private float RealAttackRangeX = 0.4f;
    public float AttackRangeY = 0;




    public void Stun(bool stuned)
    {
        Stuned = stuned;
        
    }
   



    bool Player_Detect()
        {
            return Physics2D.OverlapCircle(pos.position, radius, player);
        }

    bool Is_Ground()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.3f, groundlayer);
    }


    void Start()
    {
        pplayer = GameObject.FindWithTag("Player").GetComponent<Transform>();
        PlayerPos = pos.position;
        AttackCooldown = 1;
        
    }

   
    void Update()
    {



        rb.AddForceY(-30);


 if (Player_Detect())
        {
            PlayerPos = pplayer.transform.position;
            Vector2 player_side = PlayerPos - (Vector2)pos.position;

     
            if (pplayer.position.y > pos.position.y+1 && Is_Ground() == true && Stuned == false )
            {
                    rb.linearVelocityY = JumpPower;
                
            }


            player_side.Normalize();
            if (player_side.x != 0 && Stuned == false && GetComponent<EnemyAttack>().AttackReady == false) {
                rb.linearVelocityX = player_side.x * speed ;
            }
            else if(player_side.x != 0 && Stuned == false && GetComponent<EnemyAttack>().AttackReady == true)
            {
                
                rb.linearVelocityX = player_side.x * speed/10;
            }
            print(GetComponent<EnemyAttack>().AttackReady);
          
            

        }
        else
        {
            rb.linearVelocityX = 0; 
        }


 if (rb.linearVelocityX > 0)
        {
            spriterenderer.flipX = false;
        }
 else if(rb.linearVelocityX < 0)
        {
            spriterenderer.flipX = true;
        }


















       

 //enemy anim

 if(rb.linearVelocityX != 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

    }












    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(pos.position, radius);


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundcheck.position, 0.3f);
        Gizmos.color = Color.red;
        
        




    }


}
