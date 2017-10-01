using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public Text textDisplay;
    public string go = "<color=lime>RUN!</color>";
    public string currentWordBase;
    public int currentPos;

    public Text timer;
    public float startTime;
    public float time;
    public int maxTime;

	// Use this for initialization
	void Start () {
        textDisplay.text = go;
        time = maxTime;
    }
	
	// Update is called once per frame
	void Update () {
        time = time - Time.deltaTime;
        timer.text = ((int)(time)).ToString();
	}

    void StartClimbing(string word)
    {
        currentWordBase = word;
        currentPos = 0;
        textDisplay.text = currentWordBase;
    }

    void UpdateClimbing()
    {
        currentPos += 1;
        textDisplay.text = "<color=white>" + currentWordBase.Substring(0, currentPos) + "</color>" + currentWordBase.Substring(currentPos, currentWordBase.Length - currentPos);
    }

    void FinishClimbing()
    {
        textDisplay.text = go;
    }

    void IncreaseTime(int t)
    {
        time += t;
    }
}
