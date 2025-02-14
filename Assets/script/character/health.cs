using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class health : MonoBehaviour
{

    public float Max_Health = 100;
    public float Health = 100;
    public float deathtimer = 3;
    private Animator animator;
    private bool deathtimerbool;
    public float SetEffectDuration = 0.2f;
    private float EffectDuration;
    private SpriteRenderer spriteRenderer;
    public GameObject Text;
    private TextMeshProUGUI hptext;




    public void TakeDMG(float damage)
    {
        Health -= damage;
        GetComponent<Walking>().Stun = true;
        EffectDuration = SetEffectDuration;
        
    }

    private void Start()
    {
        hptext = Text.GetComponent<TextMeshProUGUI>();
        EffectDuration = SetEffectDuration;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }




    // Update is called once per frame
    void Update()
    {
        if (Health > Max_Health)
        {
            Health = Max_Health;
        }

        if (Health <= 0)
        {
            deathtimerbool = true;
        }

        if (deathtimerbool == true)
        {
            deathtimer -= Time.deltaTime;
            animator.SetTrigger("Death");
        }



        if (deathtimer <= 0)
        {
            SceneManager.LoadScene("death scene");
        }

       
        // Stun
      if (EffectDuration >= 0)
        {
            EffectDuration -= Time.deltaTime;
            spriteRenderer.color = Color.red;

        }
        else 
        {
            GetComponent<Walking>().Stun = false;
            spriteRenderer.color = Color.white;
        }

        if (deathtimerbool)
        {
            GetComponent<Walking>().Stun = true;
        }




    }
}
