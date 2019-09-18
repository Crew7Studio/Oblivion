using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{

    public int damageToGive;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerHealthManager.HurtPlayer(damageToGive);
            //to destroy the laser on hitting the player
            Destroy(gameObject);
        }
    }
}
