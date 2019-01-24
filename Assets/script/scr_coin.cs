using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class scr_coin : MonoBehaviour {
	float coin_speed = 0.5f;
	const float view_mini = -10;
    const float view_maxi = 90;
    const float rotation_speed = 150;
    Vector3 position;
    float dwarf_position;

	GameObject go;
    scr_score scriptsc;
	GameObject gpb;
    scr_progresse_bar scriptPB;

	int level = 0;
	bool pause = false;


    void Start(){
        position = transform.position;
        gpb = GameObject.Find("progress_bar");
        scriptPB = (scr_progresse_bar) gpb.GetComponent(typeof(scr_progresse_bar));
        go = GameObject.Find("dwarf_character");
        scriptsc = (scr_score) go.GetComponent(typeof(scr_score));
    }

    void Update(){

		level = scriptPB.getLevel();
		pause = scriptsc.pause();
        position = transform.position;
        dwarf_position = go.transform.position.x;


        if (scriptsc.ended() || position.z < view_mini){
            deleteCoin();
        }

		if (!pause){
    		position.z -= coin_speed * level;
        }


        transform.position = position;
		transform.Rotate(Vector3.down * Time.deltaTime * rotation_speed);

		if (Math.Abs(dwarf_position - position.x) < 2 && position.z < 5){ //piece attrapé
			score();
			deleteCoin();
		}
    }


    void deleteCoin(){
    	Destroy(gameObject);
    }

    void score(){
		scriptsc.gotCoin(1);
    }
}
