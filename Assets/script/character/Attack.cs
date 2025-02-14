using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    public float MeleeDmg = 20;
    public float SETMeleeCooldawn = 0.4f;
    public float MeleeCooldown = 0;
    public float Radius = 0.5f;
    private Animator anim;
    public float AttackRangepub = 1;
    private Vector2 AttackRange;
    private SpriteRenderer spriteRenderer;
    public LayerMask EnemyLayer;
    public Transform AttackLocation;
    public float AttackDamage = 20;
    public float SetDMGWAIT = 0.12f;
    private float DMGWait = 1;
    bool Attacks = false;
    

    void Start()
    {
        anim = GetComponent<Animator>();   
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void DealDamage()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(AttackRange, Radius, EnemyLayer);
        foreach (Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(AttackDamage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MeleeCooldown > 0)
        {
            MeleeCooldown -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && MeleeCooldown <= 0)
        {
            anim.SetTrigger("Attack");
            MeleeCooldown = SETMeleeCooldawn;
            DMGWait = SetDMGWAIT;
            
        }
        if(DMGWait >= 0 && DMGWait <=3)
        {
            DMGWait -= Time.deltaTime;
        }
        if (DMGWait <= 0)
        {
            DealDamage();
            DMGWait = 4;
            

        }

        if (spriteRenderer.flipX == true)
        {
            AttackRange = ((Vector2)AttackLocation.position + new Vector2(-AttackRangepub, 0));
        }
        else if (spriteRenderer.flipX == false)
        {
            AttackRange = (Vector2)AttackLocation.position + new Vector2(AttackRangepub, 0);
        }



  

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackRange, Radius);
    }






}
