using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver2 : MonoBehaviour
{
    public string mainMenuScreen;

    public Text username1, username2, score1, score2;






   // public string score;

    IEnumerator Start()
    {
        username1.text = TwoPlayerRegister.username1;
        username2.text = TwoPlayerRegister.username2;

        //getting the first score
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", TwoPlayerRegister.username1.ToString());

        WWW userData = new WWW("http://localhost/oblivion_user_data/score_PlayerOne.php");
        yield return userData;

       // int userDataString = userData.text;
        Debug.Log(TwoPlayerRegister.username1);
        Debug.Log(userData.text);

        score1.text = PlayerHealthManager.score[0].ToString();
        score2.text = ScoreManager.score.ToString();
    }


    void Update()
    {

    }

    public void MainMenu()
    {
        Application.LoadLevel(mainMenuScreen);
    }

    public void Quit()
    {
        Application.Quit();
    }
}