﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    public GameObject buttonToHighlight;

    void Start()
    {
        StartCoroutine(highlightButtonAfterFrameEnd());
    }

    public void loadScene()
    {
        Debug.Log("kk");
        SceneManager.LoadScene("mainScene");
        Debug.Log("kk2");
    }
    
    public void exitGame()
    {
        Application.Quit();
    }

    IEnumerator highlightButtonAfterFrameEnd()
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(buttonToHighlight);
    }
}
