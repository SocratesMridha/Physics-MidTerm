using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBallAI : MonoBehaviour {

    public bool Jumping;
    public bool Moving;
    bool jump;

    public float speed = 5;

    bool movingRight;

    Rigidbody rb;

    

    // Use this for initialization
    void Start () {
        movingRight = true;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float translation = Time.deltaTime * speed;
        if (Moving)
        {
            if (movingRight)
            {
                transform.Translate(translation, 0, 0);
            }
            else if (!movingRight)
            {
                transform.Translate(-translation, 0, 0);
            }
            
        }
        if (Jumping)
        {
            if (jump)
            {
                rb.AddForce(transform.up * 200);
                jump = false;
            }
            
        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Restrain")
        {
            movingRight = !movingRight;
        }
        if (col.gameObject.tag == "Ground")
        {
            jump = true;
        }


    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            jump = true;
        }
        if (col.gameObject.tag == "Ball")
        {
            if (Moving)
            {
                GameObject.Find("GameManage").GetComponent<GameManager>().score += 100;
                GameObject.Find("GameManage").GetComponent<GameManager>().numTar--;
            }
            else if (!Moving)
            {
                GameObject.Find("GameManage").GetComponent<GameManager>().score += 25;
                GameObject.Find("GameManage").GetComponent<GameManager>().numTar -= 0.5f;
            }
            
            Destroy(this.gameObject,0.5f);
        }
    }
}
