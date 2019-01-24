using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_score : MonoBehaviour {
    int score = 0;
    public Text text_score;

    void Start() {
    	init_score();
    	Updatescore();
    }

    // Update is called once per frame
    void Update() {
        Updatescore();
    }

    void init_score(){
    	score = 0;
    }
    void Updatescore(){
    	text_score.text = "Score : " + score;
    }

    public void gotCoin(int coin){
    	score += coin;
    	//Debug.Log("ding");
    }
    public void death(){
    	Debug.Log("death");
    }
}
