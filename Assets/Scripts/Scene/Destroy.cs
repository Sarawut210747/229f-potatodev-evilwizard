using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public string LoadScene;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(LoadScene);
        }
        else
        {
            Destroy(collision.gameObject);
        }
        
    }
}
