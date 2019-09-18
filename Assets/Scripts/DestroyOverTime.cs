using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    public float lifeSpan;

	void Start () {
		
	}
	
	void Update () {
        lifeSpan -= Time.deltaTime;

        if (lifeSpan <= 0)
            Destroy(gameObject);
	}
}
