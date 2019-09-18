using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowClosestPlayer : MonoBehaviour
{

    GameObject player;
    Transform target;
    float dist;
    public float moveSpeed, movingInDist;


    private float timeBtwShots;
    public float startTimeBtwShots;


    // for enemy fireing
    public GameObject laser;
    public Transform fireingPoint;//, fireingPoint2;

    RandomMovement rndMovement;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        rndMovement = FindObjectOfType<RandomMovement>();
        rndMovement.enabled = true;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            dist = Vector3.Distance(this.transform.position, player.transform.position);
         //   Debug.Log("kandae");
        }
        else
        {
            rndMovement.enabled = true;
            return;
        }

        if(dist < movingInDist)
        {
            target = player.transform;
            if (rndMovement != null)
                rndMovement.enabled = false;
            // movingInDist = dist;
        }
        else {
            if(rndMovement != null)
                rndMovement.enabled = true;
                target = null;
        }

        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.LookAt(targetPosition);

            transform.position = Vector3.Slerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
            return;


        //shooting the player
        if (timeBtwShots <= 0)
        {
            Instantiate(laser, fireingPoint.position, fireingPoint.rotation);
           //Instantiate(laser, fireingPoint2.position, fireingPoint2.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
