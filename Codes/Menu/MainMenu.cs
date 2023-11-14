using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Scene;

    public void Start()
    {
        Cursor.visible = false;
    }

    public void Update()
    {
    
    }

    public void Play()
    {
        StartCoroutine("Bruh");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void VoltarJogo()
    {
        Time.timeScale = 1;
    }

    public void cursoron()
    {
        Cursor.visible = true;
    }

    public void cursorfalse()
    {
        Cursor.visible = false;
    }

    IEnumerator Bruh()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(Scene);

    }
}