using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private Button startButton;

    private Button exitButton;

    public int sceneIndex;

    private UiManager uiManager;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
    void Start()
    {
        startButton = GetComponent<Button>();
        exitButton = GetComponent<Button>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        startButton.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(ExitGame);
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
    }
    private void Update()
    {
        if(sceneIndex >= 1)
        {
            uiManager.isPlaying = true;
        }
        else
        {
            uiManager.isPlaying = false;
        }
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
