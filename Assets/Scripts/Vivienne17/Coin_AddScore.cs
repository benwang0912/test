﻿using UnityEngine;
using System.Collections;

public class Coin_AddScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sonic")
        {
            Destroy(this.gameObject);
            GameFunction.Instance.AddScore();
        }
    }
}