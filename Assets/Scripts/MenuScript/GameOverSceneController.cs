using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneControllerMy : MonoBehaviour
{
    public Button RestarButton, Menu;

    private void Start()
    {
        RestarButton.onClick.AddListener(ChangeScene);
        Menu.onClick.AddListener(ChangeSceneMenu);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ChangeScene()
    {
        // Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("1_Prison");
    }

    public void ChangeSceneMenu()
    {
        // Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuScene");
    }
}
