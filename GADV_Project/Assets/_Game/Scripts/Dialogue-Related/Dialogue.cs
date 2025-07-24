using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float typespeed;

    private int index = 0;
    private bool dialogueActive = true;

    public System.Action OnDialogueComplete;

    private void Awake()
    {
        dialogueActive = false; // Start with dialogue inactive
        gameObject.SetActive(false); // Hide the dialogue box when done

    }

    void Start()
    {
        dialogueText.text = string.Empty;
        // Optionally start dialogue here, or trigger it from another script
        // StartDialogue();
    }

    void Update()
    {
        if (dialogueActive && Input.GetMouseButtonDown(0))
        {
            // If the current line is fully displayed, go to the next line
            if (dialogueText.text == dialogueLines[index])
            {
                NextLine();
            }
            else
            {
                // Instantly display the full current line
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        dialogueActive = true;
        dialogueText.text = string.Empty;
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return null; // wait one frame
        StartCoroutine(TypeLine());
    }


    IEnumerator TypeLine()
    {
        dialogueText.text = ""; // Clear before typing
        foreach (char letter in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typespeed);
        }
    }


    void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            OnDialogueComplete?.Invoke();
            dialogueActive = false;
            gameObject.SetActive(false); // Hide the dialogue box when done
        }
    }
}
