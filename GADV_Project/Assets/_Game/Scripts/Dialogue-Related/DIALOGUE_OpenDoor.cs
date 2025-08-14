using UnityEngine;

public class DIALOGUE_OpenDoor : MonoBehaviour
{
    private PlayerController playerController; // Reference to PlayerController for movement control
    public Dialogue dialogueBox;
    public Open_Door[] openDoors; // <-- Add this line

    public string[] pickupDialogue; // Set this in the Inspector for each item

    void Start()
    {
        // Assign both doors by name, or drag them in the Inspector
        openDoors = new Open_Door[2];
        openDoors[0] = GameObject.Find("Red_Door").GetComponent<Open_Door>();
        openDoors[1] = GameObject.Find("Green_Door").GetComponent<Open_Door>();
        playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()  
    {
        foreach (var door in openDoors)
        {
            if (dialogueBox != null && door.doorOpen)
            {
                playerController.canMove = false;
                dialogueBox.dialogueLines = new string[] { $"Player has opened {door.CheckDoorName()}_Door!" };
                dialogueBox.gameObject.SetActive(true);

                // Set up the callback to re-enable movement after dialogue
                dialogueBox.OnDialogueComplete = () => { playerController.canMove = true; };
                dialogueBox.StartDialogue();

                // Reset the flag so this only happens once
                door.doorOpen = false;
            }
        }
    }
}
