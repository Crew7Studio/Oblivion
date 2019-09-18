using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemyController : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public float damping;

    
    // for enemy fireing
    public GameObject laser;
    public Transform fireingPoint1, fireingPoint2;

    void Start() {
        
        timeBtwShots = startTimeBtwShots;

    }

    void Update() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // so that when player is dead it does not go on looking for player transform
        if (player == null)
        {
            return;
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
            {
                //vector3.slerp for smooth movement rather than the vector3.movetowards which is jumpy

                //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                transform.position = Vector3.Slerp(transform.position, player.position, speed * Time.deltaTime);

            }
            else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
            {
                //
                transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                transform.position = Vector3.Slerp(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (timeBtwShots <= 0)
            {
                Instantiate(laser, fireingPoint1.position, fireingPoint1.rotation);
                Instantiate(laser, fireingPoint2.position, fireingPoint2.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

     void FixedUpdate()
    {
        // FOLLOWING THE PLAYER
        /*
        //transform.LookAt(player);
        var lookPos = player.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        */

        // so that when player is dead it does not go on looking for player transform
        if (player == null) {
            return;
        }
        // enemy does not fall on side using this code rather than the above code
        Vector3 targetPosition = new Vector3(player.transform.position.x,
            transform.position.y,
            player.transform.position.z);
        transform.LookAt(targetPosition);
       
    }
}
