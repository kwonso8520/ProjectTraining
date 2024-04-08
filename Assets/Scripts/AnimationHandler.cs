using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    private Text ClearText;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        ClearText = FindObjectOfType<Text>();
    }
    public void SizeUpAnim()
    {
        animator.Play("Animation_Name");
    }
    public void StartSizeUp()
    {
        StartCoroutine(SizeUp());
    }
    private IEnumerator SizeUp()
    {
        for(int i = 0; i < 251; i++)
        {
            ClearText.fontSize = ClearText.fontSize + 1;
            yield return new WaitForSeconds(0.007f);
        }
    }
}