using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour{

public AudioSource clickAudio; //the audio

 public enemy enemy;

 public int clickDamage = 10;


 void Update(){
    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
        if (enemy != null) {
            enemy.TakeDamage(clickDamage);
            //add visual or sound effect here

            if (clickAudio != null){
                clickAudio.Play();
            }
        }
    }
 }
}