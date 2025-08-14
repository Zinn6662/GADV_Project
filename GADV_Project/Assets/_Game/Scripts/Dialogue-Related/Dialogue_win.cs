using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue_win : MonoBehaviour
{
    private PlayerController playerController; // Reference to PlayerController for movement control
    public Dialogue dialogueBox;
    public WinCon wincon;
    private bool won = false;

    public string winDialogue; // Set this in the Inspector for the single material

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (dialogueBox != null && wincon.isWinConReached == true)
        {
            playerController.canMove = false;
            dialogueBox.dialogueLines = new string[] { "Player has won the game!" };
            dialogueBox.gameObject.SetActive(true);

            // Set up the callback to re-enable movement after dialogue
            dialogueBox.OnDialogueComplete = () => { playerController.canMove = true; };
            dialogueBox.StartDialogue();

            // Reset the flag so this only happens once
            wincon.isWinConReached = false;
            won = true;

            



        }

        if (!dialogueBox.gameObject.activeSelf && won == true) // Check if the dialogue box is inactive
        {
            EndGame(); // Call the method to end the game
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
