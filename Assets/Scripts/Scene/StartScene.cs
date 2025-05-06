using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public string nameScene;
    public void Scene()
    {
        SceneManager.LoadScene(nameScene);

    }
}
