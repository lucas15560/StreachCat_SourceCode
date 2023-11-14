using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlock : MonoBehaviour
{
    public static int Level;
    public bool LevelSelector;
    public bool Sla;
    public int Sla2;
    public GameObject[] Key;
    public bool Hack;
    public bool resets;
    public Vector3[] Positiones;
    public Transform Player;
    public bool Menu;
    public string Scene;

    private string levelKey = "Level";

    void Start()
    {
        Level = PlayerPrefs.GetInt(levelKey, 0);

        if (resets)
        {
            ResetSave();
        }

        if (Level >= 1 && LevelSelector || Hack)
        {
            Player.position = Positiones[0];
            Key[0].SetActive(true);
        }

        if (Level >= 4 && LevelSelector || Hack)
        {
            Player.position = Positiones[1];
            Key[1].SetActive(true);
        }

        if (Level >= 6 && LevelSelector || Hack)
        {
            Player.position = Positiones[2];
            Key[2].SetActive(true);
        }

        if (Level >= 7 && LevelSelector || Hack)
        {
            Player.position = Positiones[3];
            Key[3].SetActive(true);
        }

        if (Level >= 10 && LevelSelector || Hack)
        {
            Player.position = Positiones[4];
            Key[4].SetActive(true);
        }

        if (Level >= 11 && LevelSelector || Hack)
        {
            SceneManager.LoadScene(Scene);
        }
    }

    void Update()
    {
        Sla2 = Level;
        if (Sla)
        {
            Sla = false;
            Level++;
            PlayerPrefs.SetInt(levelKey, Level);
            PlayerPrefs.Save();
        }

        if (Input.GetKeyDown(KeyCode.P) && Menu == true)
        {
            ResetSave();
        }
    }

    void ResetSave()
    {
        PlayerPrefs.DeleteKey(levelKey);
        PlayerPrefs.Save();
    }
}
