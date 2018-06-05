using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSceneChange : MonoBehaviour {

	public Image fadingBackground;
	public int nextScene;
	public Animator fadingAnimator;

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Testing");
		if(other.tag == "Player"){
			fade();
		}
	}

	void fade (){
		fadingAnimator.SetTrigger("isFadingToLighGray");
	}
}
