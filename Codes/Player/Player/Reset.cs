using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Reset : MonoBehaviour
{
    private Animator animator;
    public Transform spritePlayer;

    public bool shoted;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void ResetButton(InputAction.CallbackContext context)
    {
        shoted = context.action.triggered;

        if (shoted)
        {
            animator.Play("CutOn");
            spritePlayer.gameObject.SetActive(true);

            StartCoroutine("Bruh");
        }
    }

    IEnumerator Bruh()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
