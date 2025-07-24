using UnityEngine;

public class Progress_Tracker : MonoBehaviour
{
    private int Progress = 0;
    private int Progress_Goal = 3;
    public WinCon winCon; // Reference to the WinCon script

    public void AddProgress()
    {
        Progress++;
        Debug.Log("Progress: " + Progress + "/" + Progress_Goal);
        if (Progress >= Progress_Goal)
        {
            if (winCon != null)
            {
                winCon.WinConReached();
            }
        }
    }
    void Start()
    {
        GameObject winConObject = GameObject.FindGameObjectWithTag("WinCon");
        if (winConObject != null)
        {
            winCon = winConObject.GetComponent<WinCon>();
        }

        // Update is called once per frame
    }
}

