using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour
{
    public static void UpdateLives(bool gainLife)
    {
        //update lives UI
        var UI = GameObject.FindGameObjectWithTag("LivesText");

        if (UI == null)
            Debug.LogError("UI is Missing!");
        else
            UI.GetComponent<Text>().text = "x " + Player.CurrentLives;
    }
}
