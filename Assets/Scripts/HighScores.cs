using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
     string[] data;
    public Text username1;
    public Text score;
    int p1, p2;

  

    IEnumerator Start()
    {

        p1 = PlayerHealthManager.score[0];
        p2 = ScoreManager.score;

        WWW userData = new WWW("http://localhost/oblivion_user_data/high_score.php");
        yield return userData;

        string userDataString = userData.text;
        data = userDataString.Split('|');

        if (MainMenu.playerMode == 1)
        {
            username1.text = data[0];
            score.text = data[1];
        }
        else if (MainMenu.playerMode == 2) {
            if (p1 > p2)
            {
                username1.text = TwoPlayerRegister.username1;
                score.text = p1.ToString();
            }
            else {
                username1.text = TwoPlayerRegister.username2;
                score.text = p2.ToString();
            }
        }

         //Debug.Log(userDataString.ToString());

    }

  


}
