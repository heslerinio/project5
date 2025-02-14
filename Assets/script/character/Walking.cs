using System.Threading;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Walking : MonoBehaviour
{

    public float speed;
    public float jump_power;
    public Rigidbody2D Rb;
    public Vector2 boxscale;
    public Transform groundcheck;
    public LayerMask groundlayer;
    private int clickcounte;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public float DashCooldawnTime = 2f;
    private float Dashcooldawn;
    public float attackdetectrange;
    public bool Stun = false;

    bool Is_Ground()
    {
      return Physics2D.OverlapBox(groundcheck.position, boxscale, 0f , groundlayer);
    }
    float a = 0;
    public float dashpower = 10;

   
    





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Dashcooldawn = DashCooldawnTime;
       

    }

    // Update is called once per frame
    void Update()
    {

// moving part
        if (Stun == false)
        {
            Rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, Rb.linearVelocityY);
        }
        else
        {
            Rb.linearVelocityX = 0;
        }
        // jumping

        if (Stun == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Is_Ground())
            {
                Rb.linearVelocityY = jump_power;
            }

            if ((Input.GetKeyUp(KeyCode.Space) && Is_Ground() == false) || (Rb.linearVelocityY < 0 && Input.GetKey(KeyCode.Space) == false))
            {
                clickcounte = 0;
            }
            if (Is_Ground())
            {
                clickcounte = 1;
            }

            if (Input.GetKey(KeyCode.Space) == true && clickcounte > 0)
            {
                Rb.AddForceY(-25f);
            }
            else if (Input.GetKey(KeyCode.Space) == false)
            {
                Rb.AddForceY(-70f);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Rb.AddForceY(-200f);
            }
        }
        else
        {
            Rb.AddForceY(-100);


        }














        //animation part
        if (Input.GetKey(KeyCode.A) && GetComponent<Attack>().MeleeCooldown <= 0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) && GetComponent<Attack>().MeleeCooldown <= 0.1f)
        {
            spriteRenderer.flipX = false;
        }

        if ( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) )
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
        // Dashing part

        if (Dashcooldawn > 0)
        {
            Dashcooldawn -= Time.deltaTime;
        }

      if (Rb.linearVelocity.x > 0)
            {
                a = 1;
            }
      else if(Rb.linearVelocity.x < 0)
            {
                a = -1;
            }
         

      //es itesteba da xeli ar mokidot an mokidet tu icit ras shvebit
        if ( Input.GetKey(KeyCode.LeftShift) && Dashcooldawn <= 0f && a != 0 )  {




          



            Dashcooldawn = 3;
            print(a);

        }
    




    }
    void OnDrawGizmosSelected()
    {
        if (groundcheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(groundcheck.position, boxscale);
           
        }
    }
    
}
