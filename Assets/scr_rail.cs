using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_rail : MonoBehaviour {
    float cart_speed = 0.5f;
    const float view_mini = -6;
    const float view_maxi = 90;
    Vector3 position;

	GameObject gpb;
		GameObject go;

	int level = 0;
	bool pause = false;


    void Start(){
        position = transform.position;
        gpb = GameObject.Find("progress_bar");
        go = GameObject.Find("dwarf_character");

    }

    // Update is called once per frame
    void Update(){

		scr_progresse_bar scriptPB = (scr_progresse_bar) gpb.GetComponent(typeof(scr_progresse_bar));
		level = scriptPB.getLevel();
		scr_score scriptsc = (scr_score) go.GetComponent(typeof(scr_score));
		pause = scriptsc.pause();


    	position = transform.position;
		if (!pause){
    		position.z -= cart_speed * level;
		}
        if (position.z < view_mini){
        	position.z = view_maxi;
        }
        transform.position = position;
    }
}
