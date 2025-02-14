using UnityEngine;
using UnityEngine.SceneManagement;


public class OverWorld : MonoBehaviour
{
    public Transform transform;
    public Vector2 height;
    public LayerMask Player;
    







    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.OverlapBox(transform.position, height, 0f , Player) != null && Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene("TestLevel");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(height.x, height.y, 0));





    }
    
        
}






