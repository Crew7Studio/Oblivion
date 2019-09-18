using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    string createUserURL = "http://localhost/oblivion_user_data/register.php";

    public InputField inputUsername;
    public InputField inputPassword;
    public InputField confirmPassword;
    public Text ErrorLabel;
    string label;

    public GameObject loginCanvas;
    public GameObject registerCanvas;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ErrorLabel.text = label;
    }

    public void Registration()
    {
        label = "";
        if (inputPassword.text == confirmPassword.text)
        {
           StartCoroutine(RegisterUser(inputUsername.text, inputPassword.text));
          //  Debug.Log("passwords match");
        }
        else
        {
            label = "passwords donot match";
        }
    }

    IEnumerator RegisterUser(string username, string password)
    {
       // Debug.Log("inside registeruser()");
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW reg = new WWW(createUserURL, form);
        yield return reg;

        if (reg.text == "exists")
        {
            label = "username taken";
            ErrorLabel.text = label;
        }
        else if(reg.text == "success"){
            // Debug.Log("success");
          
            loginCanvas.SetActive(true);
            registerCanvas.SetActive(false);
        }
        else if(reg.text == "fail")
        {
            Debug.Log("fail");
        }

       
    }

    public void RegisterBackButton()
    {
       
        registerCanvas.SetActive(false);
        loginCanvas.SetActive(true);
    }

    private void OnDisable()
    {
        //resettting the fields
        label = "";
        inputUsername.text = "";
        inputPassword.text = "";
        confirmPassword.text = "";
    }

}
