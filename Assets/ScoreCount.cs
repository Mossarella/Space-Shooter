using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreCount : MonoBehaviour
{
    public int currentScore;
    public int currentHighScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int currentScene;

    private void Awake()
    {
        SetUpSingleton();

        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();

        //currentScene = SceneManager.GetActiveScene().buildIndex;

    }

    public void SetUpSingleton()
    {


        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
           
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            OnLevelWasLoaded();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        


        highScoreText.text = ("HIGHSCORE: "+ (ReturnTheScore().ToString())).ToString();
        scoreText.text = ReturnScore().ToString();

        if(currentScore>=currentHighScore)
        {
            currentHighScore = currentScore;
            TryToSetHighScore(currentScore);
        }
    }

    void OnLevelWasLoaded()
    {
       

            scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
       

       
      
          
        
        

        //Blah Blah this only works when using SceneManager.Load
    }





    public void TryToSetHighScore(int score)
    {
        currentHighScore = ReturnTheScore();
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
           
        }
      
    }
    public int ReturnTheScore()
    {
        return PlayerPrefs.GetInt("highScore");
    }

    public int ReturnScore()
    {
        return currentScore;
    }
    public void AddToScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
    }
    public void ResetScore()
    {
        currentScore = 0;
    }
   
}
