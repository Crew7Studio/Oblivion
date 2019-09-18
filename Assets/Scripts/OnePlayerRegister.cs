using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnePlayerRegister : MonoBehaviour
{
    string createUserURL = "http://localhost/oblivion_user_data/register.php";

    public InputField inputUsername;
    
    public Text ErrorLabel;
    string label;

    public string loadLevel, loadMainMenu;
    public static string username;



    // Update is called once per frame
    void Update()
    {
        ErrorLabel.text = label;
    }

    public void Registration()
    {
        label = "";
        if (inputUsername.text != null)
        {
            username = inputUsername.text.ToString();
            StartCoroutine(RegisterUser(inputUsername.text));
            //  Debug.Log("passwords match");
        }
        else
        {
            label = "username empty";
        }
    }

    IEnumerator RegisterUser(string username)
    {
        // Debug.Log("inside registeruser()");
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);

        WWW reg = new WWW(createUserURL, form);
        yield return reg;

    }

    public void StartButton() {
        Registration();
        Application.LoadLevel(loadLevel);
    }

    public void RegisterBackButton()
    {
        Application.LoadLevel(loadMainMenu);
    }

    private void OnDisable()
    {
        //resettting the fields
        label = "";
        inputUsername.text = "";
    }
}
