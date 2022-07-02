using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreCouner;
    private int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            score++;
        }

        scoreCouner.text = "Score:" + score;
    }
}
