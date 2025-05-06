using UnityEngine;

public class SceneTracker : MonoBehaviour
{
   public static string lastScene;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        lastScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}
