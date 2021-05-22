using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int score = 0;
    public Text scoreText;
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
 
}
