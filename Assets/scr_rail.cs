using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_rail : MonoBehaviour{
    float cart_speed = 0.5f;
    const float view_mini = -6;
    const float view_maxi = 90;
    Vector3 position;


    void Start(){
        position = transform.position;
    }

    // Update is called once per frame
    void Update(){
    	position = transform.position;

    	position.z -= cart_speed;
        if (position.z < view_mini){
        	position.z = view_maxi;
        }
        transform.position = position;
    }
}
