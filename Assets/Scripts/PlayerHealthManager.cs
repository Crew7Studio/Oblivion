using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int givenHealth;
    public static int maxPlayerHealth;
    public static int playerHealth;

    private LevelManager levelManager;

    // Text text;
    public Slider healthBar;

    public bool isDead;

    string insertDataURL = "http://localhost/oblivion_user_data/user_data.php";
    public string gameOverScreen, gameOverScreen2;
    public static int playerCount = 0;
    string username;


    public static int[] score;


    void Start()
    {
        score = new int[2];
        maxPlayerHealth = givenHealth;
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
        // text = GetComponent<Text>();
        healthBar = GetComponent<Slider>();
        isDead = false;
        playerCount = 0;
    }

    void Update()
    {
        if(playerHealth <= 0  && !isDead )
        {
            // Destroy(gameObject);
            playerHealth = 0;
            isDead = true;

            Debug.Log("Chathu");

            //Adding the score and username to the db
            if (MainMenu.playerMode == 1)
                OnePlayer();

            //Adding score to db and also involking the second player
            if (MainMenu.playerMode == 2)
            {
                playerCount++;
                if (playerCount == 1)
                {
                    username = TwoPlayerRegister.username1.ToString();
                    TwoPlayer(username);
                }
                else {
                    username = TwoPlayerRegister.username2.ToString();
                    TwoPlayer(username);
                }
            }

              
        }

        // text.text = "" + playerHealth;
        healthBar.value = playerHealth;
    }

    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
    }


    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }


    public static void AddHealth(int addHealth )
    {
        if(playerHealth >= maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        else
        {
            playerHealth += addHealth;
        }
    }

    public void OnePlayer() {
        if (OnePlayerRegister.username != null)
        {
            Debug.Log("inside adduser()");
          

            //  AddUser(Login.currentUser, ScoreManager.score);
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", OnePlayerRegister.username);
            form.AddField("scorePost", ScoreManager.score);

            WWW insertData = new WWW(insertDataURL, form);
        }


        Application.LoadLevel(gameOverScreen);
    }


    public void TwoPlayer(string username) {
        if (username != null)
        {

            Debug.Log("inside adduser()");

            //  AddUser(Login.currentUser, ScoreManager.score);
            WWWForm form = new WWWForm();
            form.AddField("usernamePost", username);
            form.AddField("scorePost", ScoreManager.score);

            WWW insertData = new WWW(insertDataURL, form);
        }

        if (playerCount == 1)
        {
            score[0] = ScoreManager.score;
            levelManager.RespawnPlayer();
            Debug.Log("second playr");

            //playerCount = 2;
        }else if (playerHealth <= 0)
        {
            Debug.Log("second player death1");

            score[1] = ScoreManager.score;
            Debug.Log("second player death2");
            Application.LoadLevel(gameOverScreen2);
        }
    }
}
