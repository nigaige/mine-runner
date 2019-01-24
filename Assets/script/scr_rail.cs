using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_rail : MonoBehaviour {
    float cart_speed = 0.5f;
    const float view_mini = -6;
    const float view_maxi = 90;
    Vector3 position;

    Vector3 originalPosition;

	GameObject gpb;
    scr_progresse_bar scriptPB;
     GameObject go;
    scr_score scriptsc;

	int level = 0;
	bool pause = false;
    bool ended = false;

    void Start(){
        originalPosition = transform.position;
        gpb = GameObject.Find("progress_bar");
        go = GameObject.Find("dwarf_character");
        scriptPB = (scr_progresse_bar) gpb.GetComponent(typeof(scr_progresse_bar));
        scriptsc = (scr_score) go.GetComponent(typeof(scr_score));
    }

    void Update(){

		level = scriptPB.getLevel();
		pause = scriptsc.pause();
        ended = scriptsc.ended();

        if (ended){
            transform.position = originalPosition;
        }

    	position = transform.position;
		if (!pause && !ended){
    		position.z -= cart_speed * level;
		}

        if (position.z < view_mini){
        	position.z = view_maxi;
        }
        
        transform.position = position;
    }
}
