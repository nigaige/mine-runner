using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_deathmsg : MonoBehaviour {
    Vector3 deathscreen= new Vector3(-70,0,0);
    Vector3 waitscreen= new Vector3(-10000,0,0);
	GameObject go;

    scr_score script;
    void Start() {
        go = GameObject.Find("dwarf_character");
        script = (scr_score) go.GetComponent(typeof(scr_score));
    }

    void Update(){

		if (script.ended()){
			isDead();
        } else{
			isnotDead();
		}
    }

    void isDead(){
    	transform.localPosition = deathscreen;
    }
    void isnotDead(){
    	transform.localPosition = waitscreen;
    }
}
