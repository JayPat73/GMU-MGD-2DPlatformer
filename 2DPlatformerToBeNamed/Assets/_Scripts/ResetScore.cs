using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    public void Reset()
    {
        ScoreManager.scoreManagerInstance.score = 0;
    }
}
