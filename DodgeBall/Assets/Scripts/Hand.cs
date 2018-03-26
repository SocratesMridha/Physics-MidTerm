using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour {

    public Rigidbody Ball;
    public Rigidbody ballPath;
    public Transform spawnPoint;

    public float rSpeed = 20;
    float timer;

    float maxMIN = 45;

    public float numShots = 8;

	// Use this for initialization
	void Start () {
        numShots = 8;
    }
	
	// Update is called once per frame
	void Update () {
        timer++;
        if (Input.GetKeyDown(KeyCode.Space) && numShots > 0)
        {
            Rigidbody rocketInstance;
            rocketInstance = Instantiate(Ball, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
            rocketInstance.AddForce(spawnPoint.forward * 1000);
            numShots--;
        }
        if (timer >= 50)
        {
            Rigidbody path;
            path = Instantiate(ballPath, spawnPoint.position, spawnPoint.rotation) as Rigidbody;
            path.AddForce(spawnPoint.forward * 1000);
            timer = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.left * (Time.deltaTime * rSpeed));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right * (Time.deltaTime*rSpeed));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * rSpeed));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * (Time.deltaTime * rSpeed));
        }
    }
}
