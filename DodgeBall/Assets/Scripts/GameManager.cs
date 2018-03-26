using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject[] targets;

    public GameObject panel;

    float numberOS;
    public Text shotsDis;
    public Text Hit;
    public Text ScoreDP;

    public Text  finalScore;

    //public Text Miss;

    public bool hit;
    public bool miss;
    float timer;
    public float score = 0;
    float multi;


    public float numTar;
    
    // Use this for initialization
    void Start () {
		numberOS = 8;
        multi = 5;
        numTar = 5;
        panel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        ScoreDP.text = "Score: "+score;
        shotsDis.text = "Shots Left: " + numberOS;
        if (Input.GetKeyDown(KeyCode.Space) && numberOS > 0)
        {
            numberOS--;
        }
        if (hit)
        {
            timer++;
            Hit.text = "HIT!";
            if (timer > 50)
            {
                Hit.text = "";
            }
            hit = false;
            timer = 0;

        }
        if (miss)
        {
            timer++;
            Hit.text = "MISS!";
            if (timer > 50)
            {
                Hit.text = "";
            }

            miss = false;
            timer = 0;

        }
        
        if (numberOS <=0 || numTar <= 0)
        {
            timer = 0;
            timer++;
            if (numberOS != 0)
            {
                score = score * numberOS;
            }
           
            finalScore.text = "" + score;
            
                panel.SetActive(true);
            
            //panel.SetActive(true);
        }
       
    }
    public void LoadScene(int scene)
    {
        
            SceneManager.LoadScene(scene);
        
        
        
    }
    public void ExitGame(bool yes)
    {

        if (yes)
        {
            Application.Quit();
        }



    }
}
