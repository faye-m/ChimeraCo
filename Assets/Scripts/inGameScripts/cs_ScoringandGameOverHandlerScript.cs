using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cs_ScoringandGameOverHandlerScript : MonoBehaviour
{
    //variables handling the scoring system
    [SerializeField] private int currentScore;
    [SerializeField] private int defaultScore = 0;
    [SerializeField] private int scoreAddition = 100;

    //variables handling the score UI Display;
    [SerializeField] private Text scoreText;

    //variables to handle the player lives system
    [SerializeField] private int currentPLives;
    [SerializeField] private int maxPLives = 3;
    [SerializeField] private int minPLives = 0;
    [SerializeField] private bool isDead = false;

    //variables to handle the lives UI Display
    [SerializeField] private Image[] lifeImages;

    // Start is called before the first frame update
    void Start()
    {
        SetDefaultScore();
        SetMaxLives();
    }

    // Update is called once per frame
    void Update()
    {
        OnGameisOver();
    }

    private void LateUpdate()
    {
        DisplayCurrentScore();
        DisplayCurrentLives();
    }

    public void RemoveLives()
    {
        currentPLives --;

        if (currentPLives <= minPLives)
        {
            isDead = true;
            currentPLives = 0;
        }
    }

    private void OnGameisOver()
    {
        if (isDead)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void SetMaxLives()
    {
        currentPLives = maxPLives;
        isDead = false;
    }

    private void DisplayCurrentLives()
    {
        switch (currentPLives)
        {
            case 3:
                lifeImages[2].enabled = true;
                lifeImages[1].enabled = true;
                lifeImages[0].enabled = true;
                break;
            case 2:
                lifeImages[2].enabled = false;
                lifeImages[1].enabled = true;
                lifeImages[0].enabled = true;
                break;
            case 1:
                lifeImages[2].enabled = false;
                lifeImages[1].enabled = false;
                lifeImages[0].enabled = true;
                break;
            default:
                lifeImages[2].enabled = false;
                lifeImages[1].enabled = false;
                lifeImages[0].enabled = false;
                break;
        }
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
