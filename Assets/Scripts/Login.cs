using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    public InputField inputUsername;
    public InputField inputPassword;
    public Text loginErrorText;

    public GameObject loginCanvas;
    public GameObject registerCanvas;

    string label;
    public static string currentUser;
    public string loadLevel;

    string loginURL = "http://localhost/oblivion_user_data/login.php";

    void Start()
    {
        
    }

    void Update()
    {
        loginErrorText.text = label;
    }

    public void UserLogin() => StartCoroutine(LoginToDB(inputUsername.text, inputPassword.text));

    IEnumerator LoginToDB(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW loginReader = new WWW(loginURL, form);

        yield return loginReader;
        //Debug.Log(loginReader.text);


        if (loginReader.text == "success")
        {
            label = "Logged in";
            Debug.Log("SUCCESSFUL LOGIN");
            currentUser = username;

            Application.LoadLevel(loadLevel);
        }
        else {
            label = "Incorrect username or password";
        }
    }


    public void LoginRegisterButton() {
       
        registerCanvas.SetActive(true);
        loginCanvas.SetActive(false);
    }

    private void OnDisable()
    {
        //resetting the fields
        inputUsername.text = "";
        inputPassword.text = "";
        label = "";
    }

}
