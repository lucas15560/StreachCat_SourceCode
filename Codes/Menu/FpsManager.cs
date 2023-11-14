using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FpsManager : MonoBehaviour
{
    public int FPS;
    public TMP_Text FPSSHOW;
    private float deltaTime;

    void Update() 
    {
        Application.targetFrameRate = FPS;

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        FPSSHOW.text = Mathf.Ceil(fps).ToString();
    }
}