using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutBruh : MonoBehaviour
{
    private Animator animator;
    public Transform spritePlayer;
    public bool CutOff2;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
    }

    void Update()
    {
        if(CutOff2)
        {
            CutOff();
        }
    }

    public void CutOn()
    {
        spritePlayer.gameObject.SetActive(true);
        animator.Play("CutOn");
    }

    public void CutOff()
    {
        CutOff2 = false;
        spritePlayer.gameObject.SetActive(true);
        animator.Play("CutOFF");
    }

    public void Enable()
    {
        spritePlayer.gameObject.SetActive(false);
    }
}
