using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class cs_ScoringandGameOverHandlerScript : MonoBehaviour
{
    //variables handling the scoring system
    [SerializeField] private int currentScore;
    [SerializeField] private int defaultScore = 0;
    [SerializeField] private int scoreAddition = 100;

    //variables handling the score UI Display;
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        DisplayCurrentScore();
    }

    private void SetDefaultScore()
    {
        currentScore = defaultScore;
    }

    public void AddtoScore()
    {
        currentScore += scoreAddition;
    }

    private void DisplayCurrentScore()
    {
        scoreText.text = currentScore.ToString();
    }
}
