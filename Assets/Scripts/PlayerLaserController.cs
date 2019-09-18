using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserController : MonoBehaviour {

    public float fireingSpeed;
    public int damageToGive;

	void Start () {
		
	}
	
	void Update () {
        transform.position += transform.forward * Time.deltaTime * fireingSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "BossEnemy")
        {
            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
            Destroy(gameObject);
        }
        if(other.tag == "Obstacles")
        {
            Destroy(gameObject);
        }
    }
}
