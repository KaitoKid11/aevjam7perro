using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NameSelector : MonoBehaviour {

    public Text firstLetterText;
    public Text secondLetterText;
    public Text thirdLetterText;

    public Text doneText;

    
    private string currentFirstLetter;
    private string currentSecondLetter;
    private string currentThirdLetter;


    private int currentSelectedSpace = 0;

    private bool nameSelectorActive = true;


    private List<string> possiblesLetters = new List<string>();

	void Start () {

        currentFirstLetter = "A";
        currentSecondLetter = "A";
        currentThirdLetter = "A";
        
        currentSelectedSpace = 0;
        
        possiblesLetters.Add("A");
        possiblesLetters.Add("B");
        possiblesLetters.Add("C");
        possiblesLetters.Add("D");
        possiblesLetters.Add("E");
        possiblesLetters.Add("F");
        possiblesLetters.Add("G");
        possiblesLetters.Add("H");
        possiblesLetters.Add("I");
        possiblesLetters.Add("J");
        possiblesLetters.Add("K");
        possiblesLetters.Add("L");
        possiblesLetters.Add("M");
        possiblesLetters.Add("N");
        possiblesLetters.Add("O");
        possiblesLetters.Add("P");
        possiblesLetters.Add("Q");
        possiblesLetters.Add("R");
        possiblesLetters.Add("S");
        possiblesLetters.Add("T");
        possiblesLetters.Add("U");
        possiblesLetters.Add("V");
        possiblesLetters.Add("X");
        possiblesLetters.Add("Y");
        possiblesLetters.Add("Z");

        highlightLetter();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (nameSelectorActive)
        {
            if (currentSelectedSpace == 3)
            {
              if (Input.GetButtonDown(KeyCodes.Submit))
              {
                  GUIManager.GUIManagerInstance.nameSelector.SetActive(false);
                  GUIManager.GUIManagerInstance.buttons.SetActive(true);
                  GUIManager.GUIManagerInstance.highlightPlayAgainButton();
                  
                  PersistentScore.PersistentScoreInstance.setFinalScore(GameManager.GameManagerInstance.score,currentFirstLetter+currentSecondLetter+currentThirdLetter);
                  return;
              }
            }

            if (Input.GetButtonDown(KeyCodes.Up))
            {
                if (currentSelectedSpace == 0)
                {
                    int index = possiblesLetters.IndexOf(currentFirstLetter);
                    index++;

                    if (index == possiblesLetters.Count)
                        index = 0;

                    firstLetterText.text = possiblesLetters[index];
                    currentFirstLetter = possiblesLetters[index];

                }
                else if (currentSelectedSpace == 1)
                {
                    int index = possiblesLetters.IndexOf(currentSecondLetter);
                    index++;

                    if (index == possiblesLetters.Count)
                        index = 0;

                    secondLetterText.text = possiblesLetters[index];
                    currentSecondLetter = possiblesLetters[index];
                }
                else if (currentSelectedSpace == 2)
                {
                    int index = possiblesLetters.IndexOf(currentThirdLetter);
                    index++;

                    if (index == possiblesLetters.Count)
                        index = 0;

                    thirdLetterText.text = possiblesLetters[index];
                    currentThirdLetter = possiblesLetters[index];

                }
            }
            if (Input.GetButtonDown(KeyCodes.Down))
            {
                if (currentSelectedSpace == 0)
                {
                    int index = possiblesLetters.IndexOf(currentFirstLetter);
                    index--;

                    if (index < 0)
                        index = possiblesLetters.Count - 1;

                    firstLetterText.text = possiblesLetters[index];
                    currentFirstLetter = possiblesLetters[index];
                }
                else if (currentSelectedSpace == 1)
                {
                    int index = possiblesLetters.IndexOf(currentSecondLetter);
                    index--;

                    if (index < 0)
                        index = possiblesLetters.Count - 1;

                    secondLetterText.text = possiblesLetters[index];
                    currentSecondLetter = possiblesLetters[index];
                }
                else if (currentSelectedSpace == 2)
                {
                    int index = possiblesLetters.IndexOf(currentThirdLetter);
                    index--;

                    if (index < 0)
                        index = possiblesLetters.Count - 1;

                    thirdLetterText.text = possiblesLetters[index];
                    currentThirdLetter = possiblesLetters[index];

                }
            }


            if (Input.GetButtonDown(KeyCodes.Left))
            {
                currentSelectedSpace--;

                if (currentSelectedSpace < 0)
                    currentSelectedSpace++;

                highlightLetter();

            }

            if (Input.GetButtonDown(KeyCodes.Right))
            {
                currentSelectedSpace++;

                if (currentSelectedSpace > 3)
                    currentSelectedSpace--;

                highlightLetter();

            }
        }
       
	}

    private void highlightLetter()
    {
        Debug.Log("HIGHLIGHT");
        if(currentSelectedSpace == 0)
        {
            Debug.Log("First");

            //secondLetterText.GetComponent<Animator>().SetTrigger("ToIdle");
            thirdLetterText.GetComponent<Animator>().SetTrigger("ToIdle");
            firstLetterText.GetComponent<Animator>().SetTrigger("ToHighlight");
        }
        else if (currentSelectedSpace == 1)
        {
            Debug.Log("Scond");
            firstLetterText.GetComponent<Animator>().SetTrigger("ToIdle");
            //thirdLetterText.GetComponent<Animator>().SetTrigger("ToIdle");
            //secondLetterText.GetComponent<Animator>().SetTrigger("ToHighlight");
        }
        else if (currentSelectedSpace == 2)
        {
            Debug.Log("third");
            //firstLetterText.GetComponent<Animator>().SetTrigger("ToIdle");
            //secondLetterText.GetComponent<Animator>().SetTrigger("ToIdle");
            thirdLetterText.GetComponent<Animator>().SetTrigger("ToHighlight");
        }
        else if (currentSelectedSpace == 3)
        {
            Debug.Log("Done");
            //firstLetterText.GetComponent<Animator>().SetTrigger("ToIdle");
            //secondLetterText.GetComponent<Animator>().SetTrigger("ToIdle");
            //thirdLetterText.GetComponent<Animator>().SetTrigger("ToHighlight");
            doneText.GetComponent<Animator>().SetTrigger("ToHighlight");
        }
    }
}
