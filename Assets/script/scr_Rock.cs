using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class scr_Rock : MonoBehaviour {
    float rock_speed = 0.5f;
    const float view_mini = -10;
    const float view_maxi = 90;
    const float rotation_speed = 150;
    Vector3 position;
    Vector3 dwarf_position;
    float dwarf_jumping;

    GameObject go;
    GameObject gh;
    GameObject gpb;
    scr_progresse_bar scriptPB;
    scr_score scriptsc;
    scr_mouvement script;
    scr_dwarf_height scriptH;
    int level = 0;
    bool pause = false;


    void Start(){
        position = transform.position;
        go = GameObject.Find("dwarf_character");
        gh = GameObject.Find("Character1_Hips");
        gpb = GameObject.Find("progress_bar");
        scriptPB = (scr_progresse_bar) gpb.GetComponent(typeof(scr_progresse_bar));
        scriptsc = (scr_score) go.GetComponent(typeof(scr_score));
        script = (scr_mouvement) go.GetComponent(typeof(scr_mouvement));
        scriptH = (scr_dwarf_height) gh.GetComponent(typeof(scr_dwarf_height));
    }

    void Update(){

        if (scriptsc.ended()){
            deleteRock();
        }

        dwarf_position = go.transform.position;
        dwarf_jumping = scriptH.get_Y();
        level = scriptPB.getLevel();
        pause = scriptsc.pause();

        position = transform.position;
        position.y = -2;

        if (!pause){
            position.z -= rock_speed * level;
        }

        if (position.z < view_mini){
            deleteRock();
        }

        transform.position = position;

        if (Math.Abs(dwarf_position.x - position.x) < 2 && Math.Abs(dwarf_position.z - position.z) < 3 && dwarf_jumping < 2){//rentre dans un caillou
            hit();
            deleteRock();
        }
    }

    void deleteRock(){
        Destroy(gameObject);
    }

    void hit(){
        scriptsc.death();
    }

    void getlevel(){

    }
}
