using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldEvents : MonoBehaviour {

    [Header("Level 1")]
    [Tooltip("The bathroom door object with 2d collider attatched")]
    public GameObject bathroomDoor;

    [Header("Level 2")]
    [Tooltip("Shower Sounds")]
    public AudioClip showerSounds;

    public AudioSource showerSoundSource;

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
