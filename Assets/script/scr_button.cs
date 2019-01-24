using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scr_button : MonoBehaviour
{
	public Button pauseButton;

	GameObject gd;
    scr_score scriptD;

    void Start(){
    	pauseButton.onClick.AddListener(click);
    	gd = GameObject.Find("dwarf_character");   
        scriptD = (scr_score) gd.GetComponent(typeof(scr_score));     
    }

    void click(){
		scriptD.clickPause();
    }
}
