using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button exitButton;

    private int sceneIndex;

    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        startButton.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(ExitGame);
    }
    private void LoadGameScene()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
