using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyAttack : MonoBehaviour
{
    public float AttackRangeX;
    private float RealAttackRangeX;
    public float AttackRangeY;
    public float Attackradius = 0.5f;
    public float Attackradius1;
    private Transform pos;
    public LayerMask player;
    private SpriteRenderer spriteRenderer;
    public float Damage = 20;
    








   public bool AttackReady = false;
    
       
        
    
 


    private void Attack(float Dmg)
    {

        Collider2D[] Player = Physics2D.OverlapCircleAll((Vector2)pos.position + new Vector2(RealAttackRangeX, AttackRangeY), Attackradius, player);

        foreach (Collider2D people in Player)
        {
            people.GetComponent<health>().TakeDMG(Dmg);
        }

    }





    void Start()
    {
        pos = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        



        if (spriteRenderer.flipX)
        {
            RealAttackRangeX = -AttackRangeX;
        }
        else
        {
            RealAttackRangeX = AttackRangeX;
        }


        if (Physics2D.OverlapCircle(pos.position, Attackradius1, player) != null )
        {
            AttackReady = true;
        }
        else
        {
            AttackReady = false;
        }





















    }


    private void OnDrawGizmosSelected()
    {





        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos.position, Attackradius1);
        Gizmos.DrawWireSphere((Vector2)pos.position + new Vector2(RealAttackRangeX, AttackRangeY), Attackradius);

















    }
}