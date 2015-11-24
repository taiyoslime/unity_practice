using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIscript : MonoBehaviour {
	public Text gameovertext;

	// Use this for initialization
	void Start () {
		GetComponent<Canvas>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Gameover(){
		gameovertext.text = "GAME\nOVER";
		GetComponent<Canvas>().enabled = true;
	}

	public void Goal(){
		gameovertext.text = "GOAL";
		GetComponent<Canvas>().enabled = true;
	}

	public void Retry(){
		Application.LoadLevel("Game");
	}
	
}