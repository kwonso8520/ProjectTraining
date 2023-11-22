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
    [SerializeField]
    private Button settingButton;
    [SerializeField]
    private Button manualButton;

    public int sceneIndex;

    [SerializeField]
    private GameObject mouseClick;
    [SerializeField]
    private GameObject mouseUnClick;
    [SerializeField]
    private GameObject manualObject;


    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        startButton.onClick.AddListener(LoadGameScene);
        exitButton.onClick.AddListener(ExitGame);
        manualButton.onClick.AddListener(ShowManual);
        StartCoroutine("MouseBlink");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    private void ExitGame()
    {
        Application.Quit(); 
    }
    private void ShowManual()
    {
        manualObject.SetActive(true);
    }
    public void BackTitle()
    {
        manualObject.SetActive(false);
    }
    private IEnumerator MouseBlink()
    {
        while (true)
        {
            mouseClick.SetActive(false);
            mouseUnClick.SetActive(true);
            yield return new WaitForSeconds(1f);
            mouseClick.SetActive(true);
            mouseUnClick.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }
}
