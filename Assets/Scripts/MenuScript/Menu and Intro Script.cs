using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuandIntroScript : MonoBehaviour

   

{
    public GameObject menuPanel, introPanel, introText1, introText2, introText3;

    public int contClicks = 0;

    public Button startGameButton, exitGameButton, continueButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(changeSceneAndText);
        continueButton.interactable = false;
        startGameButton.onClick.AddListener(playButtonClicked);
        exitGameButton.onClick.AddListener (ExitGame);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitGame()
    {
        Application.Quit();
    }


//PlayButtonClicked
    public void playButtonClicked()
    {
        menuPanel.SetActive(false);
        startGameButton.interactable = false;
        exitGameButton.interactable=false;

        continueButton.interactable = true;
        introPanel.SetActive(true);
    }

   
   public void changeSceneAndText()

    //INTRO SECTION
    {
        contClicks++;

        if(contClicks == 1)
        {
            introText1.SetActive(false);
            introText2.SetActive(true);
        }
        else if(contClicks == 2)
        {
            introText2.SetActive(false);
            introText3.SetActive(true);
        }
// AFTER INTRO SECTION TRANSITIONS INTO THE GAME
        if(contClicks >= 3)
        {
            introText3.SetActive(false);
            SceneManager.LoadScene("1_Prison");

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
