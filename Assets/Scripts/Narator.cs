using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narator : MonoBehaviour {

	public int currentLevel = 1;
	public int currentPart = 1;
	public Text narratorText;
    [HideInInspector]
    public float minusTime = 0f;
    [HideInInspector]
    public float customTime = 0f;

    [Serializable]
    public struct Events
    {
        public bool hasEvent;
        public string function;
        public float time;
    }

    [Serializable]
    public struct SpeechTimer
    {
        public bool timed;
        public float time;
    }

    [Serializable]
    public struct NaratorSpeech
    {
        public string narratorText;
        public int level;
        public int part;
        public SpeechTimer speechTiming;
        public Events events;
    }

    public NaratorSpeech[] naration;


	// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        customTime = Time.timeSinceLevelLoad - minusTime;
    }

    void SearchNaration()
    {
        // Find if a timed naration should be stated
        foreach (NaratorSpeech quote in naration)
        {
            if (quote.level == currentLevel && quote.part == currentPart)
            {
                if (quote.speechTiming.timed == true && quote.speechTiming.time <= customTime)
                {
                    narratorText.text = quote.narratorText;

                    if (quote.events.hasEvent == true)
                    {
                        this.GetComponent<WorldEvents>().Invoke(quote.events.function, quote.events.time);
                    }
                    Debug.Log("Minus before - " + minusTime);
                    minusTime += customTime;
                    Debug.Log("Minus after - " + minusTime);
                    customTime = Time.timeSinceLevelLoad - minusTime;
                    currentPart += 1;
                }

                else if (quote.events.hasEvent == true && quote.speechTiming.timed == false)
                {
                    this.GetComponent<WorldEvents>().Invoke(quote.events.function, quote.events.time);
                    currentPart += 1;
                }
            }
        }
    }

	// Update is called once per frame
	void Update () {
        customTime = Time.timeSinceLevelLoad - minusTime;
        Debug.Log("Test");
        SearchNaration();
    }
}
