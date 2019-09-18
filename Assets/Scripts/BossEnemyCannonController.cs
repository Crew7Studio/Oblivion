using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyCannonController : MonoBehaviour
{

    //  private PlayerController player;
    private GameObject player;

    public GameObject laser;
    public Transform fireingPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;

    float dist;
    public float followRange;
    void Start()
    {
       
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // so that no error happens when player is destroyed. since this script looks for the player always
        if (player == null)
            return;

        if (player != null) {
            dist = Vector3.Distance(this.transform.position, player.transform.position);
        }

        if(timeBtwShots <= 0 && dist < followRange)
        {
            Instantiate(laser, fireingPoint.position, fireingPoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;

        
        Vector3 targetPosition = new Vector3(player.transform.position.x,
            transform.position.y, player.transform.position.z);

        if(dist < followRange)
            transform.LookAt(targetPosition);
    }
}
