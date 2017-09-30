﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public GameObject player;

    public GameObject[] locations;
    int currentLocation = 0;

    public string[] words;
    public string currentWord;
    public int size;

    bool climbing = false;
    int currentLetter = 0;
	// Use this for initialization
	void Start () {
        size = words.Length;
        currentWord = words[(int)(Random.value * (size-1))];
	}
	
	// Update is called once per frame
	void Update () {
		if(climbing)
        {
            if(currentLetter >= currentWord.Length)
            {
                //print("got here2");
                climbing = false;
                player.SendMessage("ClimbingWallEnd");
                currentLetter = 0;
                currentLocation = 0;
            }
            else if(Input.GetKeyDown(currentWord.Substring(currentLetter,1)))
            {
                currentLocation++;
                currentLetter++;
                player.transform.position = locations[currentLocation].transform.position;
                //print("got here1");
            }
        }
	}

    void ClimbStart()
    {
        player.gameObject.SendMessage("ClimbingWallStart");
        climbing = true;
        player.transform.position = locations[currentLocation].transform.position;
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("ClimbingWallStart");
            climbing = true;
            player.transform.position = locations[currentLocation].transform.position;
        }
    }*/
}