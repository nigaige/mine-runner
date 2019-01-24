using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_deathmsg : MonoBehaviour {
    // Start is called before the first frame update
    Vector3 deathscreen= new Vector3(-70,0,0);
    Vector3 waitscreen= new Vector3(-1000,0,0);
	GameObject go;

	bool gameover = false;

    void Start()
    {
        go = GameObject.Find("dwarf_character");

    }

    // Update is called once per frame
    void Update(){
        scr_score script = (scr_score) go.GetComponent(typeof(scr_score));
		gameover = script.ended();
		Debug.Log(gameover);
		if (gameover){
			isDead();}
		else{
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
