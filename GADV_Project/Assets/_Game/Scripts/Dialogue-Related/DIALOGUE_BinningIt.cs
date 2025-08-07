using UnityEngine;

public class DIALOGUE_BinningIt : MonoBehaviour
{
    private PlayerController playerController; // Reference to PlayerController for movement control
    public Dialogue dialogueBox;
    public Binningit binningIt; // Reference to a single bin

    public string pickupDialogue; // Set this in the Inspector for the single material

    void Start()
    {
        binningIt = GameObject.Find("GreatBin").GetComponent<Binningit>();
        playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (dialogueBox != null && binningIt.isTrashBinned)
        {
            playerController.canMove = false;
            dialogueBox.dialogueLines = new string[] { "Player has disposed of Trash!" };
            dialogueBox.gameObject.SetActive(true);

            // Set up the callback to re-enable movement after dialogue
            dialogueBox.OnDialogueComplete = () => { playerController.canMove = true; };
            dialogueBox.StartDialogue();

            // Reset the flag so this only happens once
            binningIt.isTrashBinned = false;
        }
    }
}