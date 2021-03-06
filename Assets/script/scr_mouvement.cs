﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class scr_mouvement : MonoBehaviour {
	const double VIT_LATERAL = 0.5;
	double[] RAIL_X = new double[] {45 , 50 , 55};
	int onrail = 2;
	int aimed_rail = 2;
	Vector3 position;
	static bool jumping = false;

	GameObject go;
	scr_score scriptsc;

	bool pause = false;
	bool ended = false;

	Animator animator;
    

    void Start(){
    	animator = GetComponent<Animator>();
        go = GameObject.Find("dwarf_character");
		scriptsc = (scr_score) go.GetComponent(typeof(scr_score));
    }
    void Update(){

		pause = scriptsc.pause();
        ended = scriptsc.ended();

		position = transform.position;
		double aimed_X = RAIL_X[aimed_rail - 1];
		double distance = 0;
    	
		if (!pause && !ended){
			if (aimed_rail != onrail){
	    		distance = position.x - aimed_X;

	    		if (Math.Abs(distance) < VIT_LATERAL){ 	//arrivé
	    			position.x = (float)aimed_X;
	    			onrail = aimed_rail;

	    		}else if (position.x > aimed_X){	//déplace a gauche
	    			position.x -= (float)VIT_LATERAL;
	    		}else if (position.x < aimed_X){	//déplace a droite
	    			position.x += (float)VIT_LATERAL;
	    		}
	 			transform.position = position;
	    	} else {//action en fonction des inputs claviers
	    		
	    		jumping = animator.GetCurrentAnimatorStateInfo(0).IsName("jump");

	    		if (Input.GetKeyDown("space") && !jumping ){
					animator.SetTrigger("jumping");
					jumping = true;
	    		}

	    		if (Input.GetKeyDown(KeyCode.LeftArrow) && onrail != 1 && !jumping){
	    			aimed_rail--;
	    			if (!animator.GetCurrentAnimatorStateInfo(0).IsName("jump_left")){
	    				animator.SetTrigger("move_left");
	    			}
	    		} 

	    		if (Input.GetKeyDown(KeyCode.RightArrow) && onrail != 3 && !jumping){
	    			aimed_rail++;
	    			if (!animator.GetCurrentAnimatorStateInfo(0).IsName("jump_right")){
		            	animator.SetTrigger("move_right");
		        	}
	    		}
	    	}
    	}
    }

    public static bool is_jumping(){
		return jumping;
	}
	
}
