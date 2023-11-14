using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public bool paused;
    public bool shoted;
    private Animator animator;
    public Transform spritePlayer;

    public string Scene;
    public string Scene2;

    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
    }

    public void Resume()
    {
        animator.SetBool("Pauseded", false);
        Time.timeScale = 1;
        paused = false;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(Scene);
        Time.timeScale = 1;
    }

    public void BackLS()
    {
        SceneManager.LoadScene(Scene2);
        Time.timeScale = 1;
    }


    public void Pause(InputAction.CallbackContext context)
    {
        shoted = context.action.triggered;

        if (shoted && paused == false)
        {
            spritePlayer.gameObject.SetActive(true);
            animator.SetBool("Pauseded", true);
            Time.timeScale = 0;
            paused = true;
        }
    }
}
