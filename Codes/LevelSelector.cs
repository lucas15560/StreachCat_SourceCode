using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int Leveis;
    private Animator animator;
    public Transform spritePlayer;
    public bool Tocar;

    public bool shoted;

    private Animator animator2;
    public Transform spritePlayer2;

    public AudioSource audioSource;

    void Start()
    {
        animator2 = spritePlayer2.GetComponent<Animator>();
        animator = spritePlayer.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Tocando", true);
            Tocar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Tocando", false);
            Tocar = false;
        }
    }

    IEnumerator Bruh()
    {
        animator2.Play("CutOn");
        audioSource.Play();
        spritePlayer2.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Level" + Leveis);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        shoted = context.action.triggered;

        if (Tocar == true && shoted)
        {
            StartCoroutine("Bruh");
        }
    }
}
