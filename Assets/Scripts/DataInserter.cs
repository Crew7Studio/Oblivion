using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInserter : MonoBehaviour
{
    string createUserURL = "http://localhost/oblivion_user_data/insert_user.php";
    public string userName;
    public string password;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CreateUser(userName, password);
    }

    public void CreateUser(string username, string password) {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        WWW www = new WWW(createUserURL, form);
    }
}
