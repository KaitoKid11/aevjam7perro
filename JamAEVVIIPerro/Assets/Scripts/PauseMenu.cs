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
        Time.timeScale = 1.0f;
        transform.gameObject.SetActive(false);
    }

    public void loadMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
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
