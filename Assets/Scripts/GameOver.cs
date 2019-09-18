using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public string mainMenuScreen;

    public Text scoreCounter;
    public Text username;






  //  string insertDataURL = "http://localhost/oblivion_user_data/user_data.php";

    void Start()
    {
        username.text = OnePlayerRegister.username;
        scoreCounter.text = ScoreManager.score.ToString();

  //      Debug.Log(username.text);
  //      Debug.Log(scoreCounter.text);
 //       if (Login.currentUser != null)
//        {
 //           Debug.Log("inside adduser()");

            //  AddUser(Login.currentUser, ScoreManager.score);
 //           WWWForm form = new WWWForm();
//            form.AddField("usernamePost", Login.currentUser);
 //           form.AddField("scorePost", ScoreManager.score);
//
 //           WWW insertData = new WWW(insertDataURL, form);
 //       }
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

 

 //   IEnumerator AddUser(string username, int score) {
 //       Debug.Log("inside adduser()");
 //      WWWForm form = new WWWForm();
 //       form.AddField("usernamePost", username);
 //       form.AddField("scorePost", score);

//        WWW insertData = new WWW(insertDataURL, form);
//        yield return insertData;
//    }
}
