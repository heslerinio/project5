using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
