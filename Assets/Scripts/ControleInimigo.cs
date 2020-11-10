﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigo : MonoBehaviour
{
    private Rigidbody2D rig;
    private float mov = 1F;
    public GameObject sons;

    

    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()  {
        if (mov>0) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (mov<0) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        rig.velocity = new Vector2(mov, rig.velocity.y);
    }
  

      void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            if (col.gameObject.transform.position.y > gameObject.transform.position.y+1) {
                sons.GetComponents<AudioSource>()[2].Play();
                Destroy(gameObject);
            } else {
                sons.GetComponents<AudioSource>()[1].Play();
                Destroy(col.gameObject);
            }
        } else if (col.gameObject.tag == "Fire") {
            sons.GetComponents<AudioSource>()[2].Play();
            Destroy(gameObject);
        } else {
            mov = mov * -1;
        }
          if(col.gameObject.CompareTag("Coins")){
              Destroy(col.gameObject);

         }   

    }
}
    