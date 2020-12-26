using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using System;

public class TitleSceneManager : MonoBehaviour
{
    public Button_UI playButton;
    public Button_UI quitButton;
    public SoundsManager soundsManager;
    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
        playButton.GetComponent<Button_UI>().ClickFunc = () =>
        {
            StartCoroutine(LoadGameScene());
            
        };
        playButton.MouseOverOnceFunc += () => { soundsManager.PlaySound(0); };
        playButton.ClickFunc += () => { soundsManager.PlaySound(1); };
        
        quitButton.GetComponent<Button_UI>().ClickFunc = () =>
        {
            Application.Quit();
        };
        quitButton.MouseOverOnceFunc += () => { soundsManager.PlaySound(0); };
        quitButton.ClickFunc += () => { soundsManager.PlaySound(3); };
    }

    public IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
