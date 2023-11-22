using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject leftEnemy = GameObject.FindGameObjectWithTag("Enemy");
        if(leftEnemy == null)
        {
            gm.LoadGameScene();
        }
    }
}
