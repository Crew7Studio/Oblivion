using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    Text text;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.playerMode == 1)
            text.text = OnePlayerRegister.username;
        else if (MainMenu.playerMode == 2) {
            Debug.Log("player mode 2");

            if (PlayerHealthManager.playerCount < 1)
            {
                Debug.Log("user name");
                Debug.Log(TwoPlayerRegister.username1);

                text.text = TwoPlayerRegister.username1;
            }
            else if(PlayerHealthManager.playerCount >= 1) {
                text.text = TwoPlayerRegister.username2;
            }
        }
    }
}
