using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorSceneChange : MonoBehaviour {

	public Image fadingBackground;
	public int nextScene;
    public Animator fadingAnimator;
    public float timeToChange;
    public string animationTriggerName;

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
            Fade();
            Invoke("changeScene", 4f);
		}
	}

	void Fade (){
		fadingAnimator.SetTrigger(animationTriggerName);
	}

    void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
