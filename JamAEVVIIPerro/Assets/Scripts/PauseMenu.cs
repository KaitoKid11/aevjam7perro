using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public GameObject buttonToHighlight;

    void Start()
    {
        StartCoroutine(highlightButtonAfterFrameEnd());
    }


    //ToDo añadir que el pauseMwnu se active en el gameManager
    //ToDo que se pare el juego

    void Update()
    {
        if (Input.GetButtonDown(KeyCodes.Esc))
        {
            transform.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    public void resumeGame()
    {
        Debug.Log("kk1");
        transform.gameObject.SetActive(false);
    }

    public void loadMainMenu()
    {
        Debug.Log("kk2");
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Debug.Log("kk3");
        Application.Quit();
    }

    IEnumerator highlightButtonAfterFrameEnd()
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(buttonToHighlight);
    }

}
