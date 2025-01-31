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
    bool Is_Ground()
    {
      return Physics2D.OverlapBox(groundcheck.position, boxscale, 0f , groundlayer);
    }

  






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

  

    }

    // Update is called once per frame
    void Update()
    {


// moving part
        Rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal")*speed,Rb.linearVelocityY);
// jumping

        if (Input.GetKeyDown(KeyCode.Space) && Is_Ground())
        {
            Rb.linearVelocityY = jump_power;
        }

        if((Input.GetKeyUp(KeyCode.Space) && Is_Ground() == false) || (Rb.linearVelocityY < 0 && Input.GetKey(KeyCode.Space) == false))
        {
            clickcounte = 0;
        }
        if (Is_Ground())
        {
            clickcounte = 1;
        }

        if (Input.GetKey(KeyCode.Space) == true && clickcounte > 0)
        {
            Rb.AddForceY(-30f);
        }
        else if(Input.GetKey(KeyCode.Space) == false)
        {
            Rb.AddForceY(-70f);
        }

        Debug.Log(clickcounte);

        //animation part
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
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






        

    }
    void OnDrawGizmos()
    {
        if (groundcheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(groundcheck.position, boxscale);
        }
    }
    
}
