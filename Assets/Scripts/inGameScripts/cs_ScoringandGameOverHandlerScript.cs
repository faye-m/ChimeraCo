using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_ScoringandGameOverHandlerScript : MonoBehaviour
{
    //variables handling the scoring system
    [SerializeField] private static int currentScore;
    [SerializeField] private int defaultScore = 0;
    [SerializeField] private static int scoreAddition = 100;

    //variables handling the score UI Display;

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDefaultScore()
    {
        currentScore = defaultScore;
    }

    public static void AddtoScore()
    {
        currentScore += scoreAddition;
    }
}
