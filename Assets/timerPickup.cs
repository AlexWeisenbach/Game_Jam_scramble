using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerPickup : MonoBehaviour {

    public GameObject controller;
    public int timeBonus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controller.SendMessage("IncreaseTime", timeBonus);
            Destroy(gameObject);
        }
    }
}
