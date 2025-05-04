using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sing : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public string cityName = "Cattio";

    private bool playerInRange = false;
    private bool messageShowing = false;
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !messageShowing)
        {
            StartCoroutine(ShowCityName());
        }
    }

    IEnumerator ShowCityName()
    {
        messageShowing = true;
        messageText.text = cityName;
        messagePanel.SetActive(true);

        CanvasGroup canvasGroup = messagePanel.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;

        yield return new WaitForSeconds(2f);

        float fadeTime = 1f;
        float timer = 0f;
        while (timer < fadeTime)
        {
            canvasGroup.alpha = 1 - (timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }

        messagePanel.SetActive(false);
        canvasGroup.alpha = 1;
        messageShowing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            playerInRange = false;        
    }
}
