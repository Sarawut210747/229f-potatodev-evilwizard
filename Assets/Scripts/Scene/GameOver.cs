using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public string LoadScene;
     public void RestartGame()
    {
        SceneManager.LoadScene(LoadScene);
    }
}
