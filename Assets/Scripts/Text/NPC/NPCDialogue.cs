using System.Collections;
using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePaneal;
    public TextMeshProUGUI dialogueText;
    public string[] dailogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (!dialoguePaneal.activeInHierarchy)
            {
                dialoguePaneal.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dailogue[index])
            {
                NextLine();
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && dialoguePaneal.activeInHierarchy)
        {
            RemoveText();
        }
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePaneal.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dailogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dailogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
        }
    }
}

