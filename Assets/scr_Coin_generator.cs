using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scr_Coin_generator : MonoBehaviour {
	public Transform Coin;
	public Transform Red_Coin;
	public Transform Rock;
	Vector3 Rail1_Spawn = new Vector3(45f,3f,100f);
	Vector3 Rail2_Spawn = new Vector3(50f,3f,100f);
	Vector3 Rail3_Spawn = new Vector3(55f,3f,100f);
	int timer = 0;
	int sequence = 0;
	int wave_coin = 0;
	const int coin_intervall = 25;
	const int next_wave = 50;
	System.Random random = new System.Random();
	int randomNumber;

	int Rock_timer = 0;




    void Start(){
        
    }

    void Update(){
    	
    	//gestion coin
    	if (timer == 0){
    		if (sequence == 0){
    			sequence = random.Next(1, 5);
	    		 wave_coin = 5;
    		}

    		switch(sequence){
    			case 1:
    			case 2:
    			case 3:
    				timer = coin_intervall;
    				if (wave_coin!=1){
	    				newObject(sequence, Coin);
	    			}else {
	    				newObject(sequence, Red_Coin);
	    			}
    			 wave_coin--;
    				if  (wave_coin == 0){
    					endWave();
    				}
    				break;
    			case 4:
	    			timer = coin_intervall;
	    			if (wave_coin!=1){
	    				newObject(1 + wave_coin%2, Coin);
	    			}else {
	    				newObject(1 + wave_coin%2, Red_Coin);
	    			}

	    		 wave_coin--;
	    			if  (wave_coin == 0){
    					endWave();
    				}
    				break;
    			default:
    				Debug.Log("error at coin generation");
    				break;	
    		}

    	}else {
    		timer--;
    	}

    	//gestion rock
    	if (Rock_timer == 0){
    		newObject(random.Next(1, 5), Rock);
    		Rock_timer = 50;
    	}else{
    		Rock_timer--;
    	}


    }

    void endWave(){
    	sequence = 0;
    	timer = next_wave;
    }

    void newObject(int Rail, Transform obj){
    	switch(Rail){
    		case 1:
    			Instantiate(obj,Rail1_Spawn, Quaternion.identity);
    			break;
    		case 2:
    			Instantiate(obj,Rail2_Spawn, Quaternion.identity);
    			break;
    		case 3:
    			Instantiate(obj,Rail3_Spawn, Quaternion.identity);
    			break;
    		default:
    			break;
    	}
    	

    }


}
