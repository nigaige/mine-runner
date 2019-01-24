using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class scr_Red_coin : MonoBehaviour {
	float coin_speed = 0.5f;
	const float view_mini = -10;
    const float view_maxi = 90;
    const float rotation_speed = 150;
    Vector3 position;
    float dwarf_position;

	GameObject go;




    void Start(){
        position = transform.position;
    }

    void Update(){
    	position = transform.position;
		dwarf_position = GameObject.Find("dwarf_character").transform.position.x;



    	position.z -= coin_speed;
        if (position.z < view_mini){
        	deleteCoin();
        }
        transform.position = position;

		transform.Rotate(Vector3.down * Time.deltaTime * rotation_speed);

		if (Math.Abs(dwarf_position - position.x) < 2 && position.z < 5){
			score();
			deleteCoin();
		}


    }



    void deleteCoin(){
    	Destroy(gameObject);
    }

    void score(){
    	//GameObject.Find("dwarf_character").gotCoin();
    	go = GameObject.Find("dwarf_character");

        scr_score script = (scr_score) go.GetComponent(typeof(scr_score));
		script.gotCoin(5);
    }
}
