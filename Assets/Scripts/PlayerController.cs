using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    Vector3 moveDir;

    Rigidbody rigidBody;

    //for rotating the player
    public float rotationSpeed;
    private float rotation;

    //for firing
    public GameObject laser;
    public Transform fireingPoint1;//, fireingPoint2;
    public float shotDelay;
    private float shotDelayCounter;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
       // Debug.Log(Login.currentUser);
    }

    void Update () {
        rotation = Input.GetAxisRaw("Horizontal");
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;


        if (Input.GetButtonDown("Fire1")){
            shotDelayCounter = shotDelay;
            Fire();
        }

        if (Input.GetButton("Fire1")){
            shotDelayCounter -= Time.deltaTime;

            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Fire();
            }
        }
    }

    void FixedUpdate () {
        rigidBody.MovePosition(rigidBody.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);

        /*
        //player rotation mechanics
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rigidBody.rotation * deltaRotation;
        rigidBody.MoveRotation(Quaternion.Slerp(rigidBody.rotation, targetRotation, 50f * Time.deltaTime));
        */
        transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);
    }


    //fireing mechanics
    public void Fire() {
       GameObject bullet = (GameObject)Instantiate(laser, fireingPoint1.position, fireingPoint1.rotation);
        //  Instantiate(laser, fireingPoint2.position, fireingPoint2.rotation);

        //spawn the bullet on the client
       // NetworkServer.Spawn(bullet);
    }

}
