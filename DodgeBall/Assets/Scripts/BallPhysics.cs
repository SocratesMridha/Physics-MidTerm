using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour {
    public bool realBall;
	// Use this for initialization
	void Start () {
        realBall = false;
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject,2);
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            GameObject.Find("GameManage").GetComponent<GameManager>().hit = true;
        }
        else if (collision.gameObject.tag == "Ground" && realBall)
        {
            GameObject.Find("GameManage").GetComponent<GameManager>().miss = true;
        }
        else
            GameObject.Find("GameManage").GetComponent<GameManager>().miss = true;
        Destroy(this.gameObject);
    }
}
