using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using System;

public class GameOverSceneManager : MonoBehaviour
{
    public Button_UI retryButton;
    public Button_UI menuButton;
    public SoundsManager soundsManager;
    public ScoreCount scoreCount;


    void Start()
    {
     

        soundsManager = FindObjectOfType<SoundsManager>();
        retryButton.GetComponent<Button_UI>().ClickFunc = () =>
        {
            StartCoroutine(LoadGameScene());

        };
        retryButton.MouseOverOnceFunc += () => { soundsManager.PlaySound(0); };
        retryButton.ClickFunc += () => { soundsManager.PlaySound(1); };

        menuButton.GetComponent<Button_UI>().ClickFunc = () =>
        {
            StartCoroutine(LoadMenuScene());
        };
        menuButton.MouseOverOnceFunc += () => { soundsManager.PlaySound(0); };
        menuButton.ClickFunc += () => { soundsManager.PlaySound(3); };
    }

    public IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
        scoreCount = FindObjectOfType<ScoreCount>();
        scoreCount.ResetScore();
        Debug.Log("hmmmm");
    }
    public IEnumerator LoadMenuScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
        scoreCount = FindObjectOfType<ScoreCount>();
        scoreCount.ResetScore();
        Destroy(scoreCount.gameObject);
        Debug.Log("hmmmsafam");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
