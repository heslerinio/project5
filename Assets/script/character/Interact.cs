using UnityEngine;

public class Interact : MonoBehaviour
{
    public float radius = 0.5f;
    public Transform transform;








    public void PlayerInteract()
    {
        Physics2D.OverlapCircle(transform.position, 1);
    }







    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
