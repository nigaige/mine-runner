using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_progresse_bar : MonoBehaviour {
	float progress = 0;
	Vector3 Scale;
	Vector3 position;
	int level = 1;

	bool pause = false;
    bool ended = false;

    GameObject go;
    scr_score scriptsc;

    void Start() {
        go = GameObject.Find("dwarf_character");
        scriptsc = (scr_score) go.GetComponent(typeof(scr_score));
    }

    void Update() {

		pause = scriptsc.pause();
    	ended = scriptsc.ended();


        Scale = transform.localScale;
    	Scale.x = progress;
    	
    	if (!pause && !ended) {
    		progress++;
    	}
    	transform.localScale = Scale;
    	if(progress == 300) {
    		progress = 0;
			level++;
    	}

    }

    public int getLevel() {
    	return level;
    }

    public void reset() {
        level = 1;
        progress = 0;
    }

}
