using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    Rigidbody rb;

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    public float characterVelocity = 2f;
    private Vector2 movementDirection;
   // private Vector2 movementPerSecond;



    void Start() {
        rb = GetComponent<Rigidbody>();

        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }


    void Update() {

      

        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime) {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
            transform.rotation = Random.rotation;

        }

        //move enemy: 
        // transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime), 0,
        //  transform.position.z + (movementPerSecond.y * Time.deltaTime));

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(movementDirection) * characterVelocity * Time.deltaTime);
    }


    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
       // movementPerSecond = movementDirection * characterVelocity;
    }
}
