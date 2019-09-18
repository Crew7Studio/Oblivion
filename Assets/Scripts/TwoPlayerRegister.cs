using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoPlayerRegister : MonoBehaviour
{
    string createUserURL = "http://localhost/oblivion_user_data/register.php";

    public InputField inputUsername1;
    public InputField inputUsername2;

    public Text ErrorLabel;
    string label;

    public string loadLevel, loadMainMenu;
    public static string username1, username2;



    // Update is called once per frame
    void Update()
    {
        ErrorLabel.text = label;
    }

    public void Registration()
    {
        label = "";
        if (inputUsername1.text != inputUsername2.text)
        {
            if (inputUsername1.text != "" && inputUsername2.text != "")
            {
                username1 = inputUsername1.text.ToString();
                StartCoroutine(RegisterUser(inputUsername1.text));

                username2 = inputUsername2.text.ToString();
                StartCoroutine(RegisterUser(inputUsername2.text));
                //  Debug.Log("passwords match");

                Application.LoadLevel(loadLevel);

            }
            else
            {
                label = "username empty";
            }
        }
        else
            label = "same username";

    }

    IEnumerator RegisterUser(string username)
    {
        // Debug.Log("inside registeruser()");
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);

        WWW reg = new WWW(createUserURL, form);
        yield return reg;

    }

    public void StartButton()
    {
        Registration();
    }

    public void RegisterBackButton()
    {
        Application.LoadLevel(loadMainMenu);
    }

    public void playerOneClearButton() {
        inputUsername1.text = "";
    }
    public void playerTwoClearButton()
    {
        inputUsername2.text = "";
    }

    private void OnDisable()
    {
        //resettting the fields
        label = "";
        inputUsername1.text = "";
        inputUsername2.text = "";
    }
}
