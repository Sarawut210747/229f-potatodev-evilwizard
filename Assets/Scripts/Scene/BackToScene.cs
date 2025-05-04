using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToScene : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int previousIndex = currentIndex - 1;

            if (previousIndex >= 0)
            {
                SceneManager.LoadScene(previousIndex);
            }
        }
    }
}
