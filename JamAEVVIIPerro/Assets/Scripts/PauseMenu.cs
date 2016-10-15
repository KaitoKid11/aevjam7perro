using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public GameObject buttonToHighlight;
    float normalTimeScale;

    void Start()
    {
        normalTimeScale = Time.timeScale;
        StartCoroutine(highlightButtonAfterFrameEnd());
    }


    //ToDo añadir que el pauseMwnu se active en el gameManager
    //ToDo que se pare el juego

    void Update()
    {
        if (Input.GetButtonDown(KeyCodes.Esc))
        {
            Debug.Log("kk");
            transform.gameObject.SetActive(false);
            //TODO parar juego
            Time.timeScale = normalTimeScale;
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
