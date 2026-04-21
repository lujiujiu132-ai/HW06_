using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EX_ScoreManager : MonoBehaviour
{
    public TMP_Text text; // score text 
    int currentScore = 0;
    public int hitPoint = 1;

    public void AddScore()
    {
        currentScore += hitPoint;
        text.text = currentScore.ToString();
    }

    // TEST
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddScore();
        }
    }
}
