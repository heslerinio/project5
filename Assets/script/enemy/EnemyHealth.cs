using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float MaxHealth = 100;
    public float CurrentHealth = 100;
    public bool DeathTimer = false;
    public float DeathCountdown = 2;
    bool Takedamage = false;
    private float Stunduration;
    private float SetStunDuration = 0.45f;
    public Animator anim;




    public void TakeDamage(float Damage)
    {
        CurrentHealth -= Damage;



        Stunduration = SetStunDuration;
    
    }










    void Start()
    {
        anim = GetComponent<Animator>();
        





    }

    void Update()
    {
        
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        if (CurrentHealth <= 0)
        {
            DeathTimer = true;
        }
        if (DeathTimer)
        {
            DeathCountdown -= Time.deltaTime;

            
            GetComponent<enemy>().Stun(true);
            

        }
        if(DeathCountdown <= 0)
        {
            Destroy(gameObject);
        }



        if (Stunduration > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<enemy>().Stun(false);
            Stunduration -= Time.deltaTime;
        }
        else if (Stunduration <= 0 && DeathTimer == false)
            {

            GetComponent<SpriteRenderer>().color = Color.white;
            GetComponent<enemy>().Stun(false);
            
            
        }

        


    }
}
