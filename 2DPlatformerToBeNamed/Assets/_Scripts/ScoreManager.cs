using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManagerInstance;
    [SerializeField] public TextMeshProUGUI scoreText;
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        if(scoreManagerInstance == null)
        {
            scoreManagerInstance = this;
        }
        else
        {
            Destroy(this);
        }

        scoreManagerInstance.scoreText.text = scoreManagerInstance.score.ToString();
    }

    
}
