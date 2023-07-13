using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinSceneController : MonoBehaviour
{
    public Button Menu, ExitButton;

    private void Start()
    {
        ExitButton.onClick.AddListener(ExitGame);
        Menu.onClick.AddListener(ChangeSceneMenu);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ChangeSceneMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
