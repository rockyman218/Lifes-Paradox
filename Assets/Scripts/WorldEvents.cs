﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldEvents : MonoBehaviour {

    public GameObject bathroomDoor;

    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }


    public void BathroomDoorAppear()
    {
        bathroomDoor.SetActive(true);
    }
}
