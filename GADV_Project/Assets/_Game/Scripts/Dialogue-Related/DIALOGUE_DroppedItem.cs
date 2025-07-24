using UnityEngine;

public class DIALOGUE_DroppedItem : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private PlayerController playerController; // Reference to PlayerController for movement control
    public Dialogue dialogueBox;

    public string[] pickupDialogue; // Set this in the Inspector for each item

    void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerController = GetComponent<PlayerController>();

    }

    private void FixedUpdate()
    {
        if (dialogueBox != null && playerInventory.itemDropped)
        {
            playerController.canMove = false;
            // Get the current item from the player's inventory
            GameObject currentItem = playerInventory != null ? playerInventory.GetCurrentItem() : null;
            string itemName = currentItem != null ? currentItem.name : "Unknown Item";

            // Set the dialogue line dynamically
            dialogueBox.dialogueLines = new string[] { $"Player has dropped up {itemName}" };
            dialogueBox.gameObject.SetActive(true);

            // Set up the callback to re-enable movement after dialogue
            dialogueBox.OnDialogueComplete = () => { playerController.canMove = true; };
            dialogueBox.StartDialogue();

            // Reset the flag so this only happens once
            playerInventory.itemDropped = false;
        }
    }
}
