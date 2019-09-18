

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string onePlayer, twoPlayer;

    public static int playerMode;


    public void OnePlayer()
    {
        playerMode = 1;
        Application.LoadLevel(onePlayer);
    }
    public void TwoPlayer()
    {
        playerMode = 2;
        Application.LoadLevel(twoPlayer);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
