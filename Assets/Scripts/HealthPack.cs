using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int addHealth;

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
            PlayerHealthManager.AddHealth(addHealth);
            Destroy(gameObject);
        }
    }
}
