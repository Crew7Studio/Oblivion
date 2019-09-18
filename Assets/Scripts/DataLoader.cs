using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    public string[] data;

    IEnumerator Start()
    {
        WWW userData = new WWW("http://localhost/oblivion_user_data/user_data.php");
        yield return userData;

        string userDataString = userData.text;

        //Debug.Log(userDataString);
        data = userDataString.Split(';');

        Debug.Log(GetDataValues(data[0], "SCORE:"));
    }


    string GetDataValues(string data, string index) {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
   
}
