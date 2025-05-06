using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string LoadScene; 
    public GameObject pauseMenuUI;  
    private bool isPaused = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);  // ซ่อนเมนู
        Time.timeScale = 1f;           // กลับมาเล่นเกมต่อ
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);  // แสดงเมนู
        Time.timeScale = 0f;          // หยุดเกม
        isPaused = true;
    }

    public void QuitGame()
    {
       Debug.Log("Quit Game!");
       SceneManager.LoadScene(LoadScene);  // ออกจากเกม (ใช้ได้เมื่อ Build จริง)
    }
}
