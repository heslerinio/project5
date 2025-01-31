using System;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float radius;
    public LayerMask player;
    public Transform pplayer;
    private Vector2 PlayerPos;
    public float speed;
    public float JumpPower;
    public Transform groundcheck;
    public LayerMask groundlayer;

    bool Player_Detect()
        {
            return Physics2D.OverlapCircle(transform.position, radius, player);
        }

    bool Is_Ground()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.3f, groundlayer);
    }


    void Start()
    {

        PlayerPos = transform.position;







    }

   
    void Update()
    {
        rb.AddForceY(-30);


 if (Player_Detect())
        {
            PlayerPos = pplayer.transform.position;
            Vector2 player_side = PlayerPos - (Vector2)transform.position;

     
                if (pplayer.position.y > transform.position.y+1 && Is_Ground() == true)
                {
                    rb.linearVelocityY = JumpPower;
                
                }


            player_side.Normalize();
            if (player_side.x != 0 ) {
                rb.linearVelocityX = player_side.x * speed;
            }

          


        }








    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(groundcheck.position, 0.3f);


        
    }


}
