using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scr_button : MonoBehaviour
{
	public Button pauseButton;

	GameObject gd;

    void Start(){
    	pauseButton.onClick.AddListener(click);
    	gd = GameObject.Find("dwarf_character");

        
    }

    // Update is called once per frame
    void Update(){

		
    }

    void click(){
    	Debug.Log("click");
    	scr_score scriptD = (scr_score) gd.GetComponent(typeof(scr_score));
		scriptD.clickPause();
    }
}
