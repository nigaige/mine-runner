using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_score : MonoBehaviour {
    int score = 0;
    public Text text_score;
    int level;
	GameObject gpb;
	bool dead = false;
	bool paused = false;
	GameObject gds;
	GameObject gdm;
	Vector3 positionMsg;


    void Start() {
    	init_score();
    	Updatescore();
    	gpb = GameObject.Find("progress_bar");
    	gds = GameObject.Find("deathscreen");
    	gdm = GameObject.Find("death_msg");

    }

    // Update is called once per frame
    void Update() {
    	scr_progresse_bar scriptPB = (scr_progresse_bar) gpb.GetComponent(typeof(scr_progresse_bar));
		level = scriptPB.getLevel();
        Updatescore();


        if (dead){
            if (Input.GetKeyDown("space")){
                dead = false;
                score = 0;
                scriptPB.reset();
            }
        }
    }

    void init_score(){
    	score = 0;
    }
    void Updatescore(){
    	text_score.text = "Score : " + score + "\nLevel : " + level;
    }

    public void gotCoin(int coin){
    	score += coin;
    	//Debug.Log("ding");
    }

    public void clickPause(){
    	paused = !paused;
    }

    public bool pause(){
    	return paused;
    }
    public bool ended(){
    	return dead;
    }

    public void death(){
    	Debug.Log("death");

    	dead = true;

    }
}
