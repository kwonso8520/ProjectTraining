using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager _instance;

    private GameObject gameOverText;
    private GameObject gauge;
    private GameObject player;
    private Image mouseManual;
    private Sprite[] mouseImages;
    public bool isPlaying = false;
    // Start is called before the first frame update
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
        gameOverText = GameObject.Find("GameOverText");
        gauge = GameObject.Find("Gauge");
        mouseManual = GameObject.Find("Mouse").GetComponent<Image>();

        player = GameObject.Find("Player");
        if (!isPlaying && player == null)
        {
            StartCoroutine("MouseBlink");
        }
    }

    // Update is called once per frame
    void Update()
    {
        gauge = GameObject.Find("Gauge");
        gameOverText = GameObject.Find("GameOverText");
        if (player == null && isPlaying)
        {
            gauge.SetActive(false);
            gameOverText.SetActive(true);
        }
    }
    private IEnumerator MouseBlink()
    {
        while (true)
        {
            mouseManual.sprite = mouseImages[0];
            yield return new WaitForSeconds(0.5f);
            mouseManual.sprite = mouseImages[1];
            yield return new WaitForSeconds(0.5f);
        }
    }
}
