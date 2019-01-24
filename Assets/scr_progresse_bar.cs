using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_progresse_bar : MonoBehaviour
{
	float progress = 1;
	Vector3 Scale;
	Vector3 position;
	GameObject go;
	int level = 1;
	bool pause = false;

    void Start(){
                go = GameObject.Find("dwarf_character");

    }

    // Update is called once per frame
    void Update(){

    	scr_score scriptsc = (scr_score) go.GetComponent(typeof(scr_score));
		pause = scriptsc.pause();
    	Scale = transform.localScale;
    	Scale.x = progress;
    	
    	if (!pause){
    		progress++;
    	}
    	transform.localScale = Scale;
    	if(progress == 300){
    		progress = 0;
			level++;
    	}

    }

    public int getLevel(){
    	return level;
    }

}
