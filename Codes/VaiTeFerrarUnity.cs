using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VaiTeFerrarUnity : MonoBehaviour
{
    public static int Vsf;
    void Start()
    {
        if(Vsf == 0)
        {
            Vsf++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
