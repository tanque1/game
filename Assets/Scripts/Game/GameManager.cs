using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPipeInLevel1;

    public static GameObject Mario;

    private void Awake()
    {
        Debug.Log("LoadPlayer");
        Mario = GameObject.FindGameObjectWithTag("Player");
    }

    public static void LoadScene(string name)
    {
    }

    public static void LoadUI()
    {
    }

    public static void HandleLevel1Reloaded()
    {
    }
}
