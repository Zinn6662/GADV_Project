using UnityEngine;

public class Master : MonoBehaviour
{
    public QuestionManager quizManager; // imlazy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (quizManager.hasFinishedQuiz == false )
            {
                Debug.Log("Send Help.");
                quizManager.ActivateQnA();
            }
                


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
