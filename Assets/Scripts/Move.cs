using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour {
	public float speed = 5;
	protected Animator animator;
	public Text gameovertext;
	float x;
	private UIscript uiscript;
	
	void Start () {
		animator = GetComponent <Animator> ();
	}


	void Update () {
		//3
		transform.position += transform.forward * speed *Time.deltaTime;

		// 4 
		if (Input.GetKey ("up")) {
						animator.SetBool ("JUMP", true);
				}
		if (Input.GetKeyUp ("up")) {
			animator.SetBool ("JUMP", false);
		}


		if (Input.GetKey ("down")) {
			animator.SetBool ("SLIDE", true);
				}
		if (Input.GetKeyUp ("down")) {
			animator.SetBool ("SLIDE", false);
		}

		// 3 move
		x = gameObject.transform.position.x;
		/*if (x <= -1.90f) {
			transform.position = new Vector3 (-3.0f, 0, 10.0f);
			
			//6 UI
			GameObject.Find("Canvas").GetComponent<UIscript> ().Gameover();


		}

		if (x >= 1.90f) {

			transform.position = new Vector3 (3.0f, 0, 10.0f);
			
			//6 UI
			GameObject.Find("Canvas").GetComponent<UIscript> ().Gameover();

		}

*/




			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate(0,-3.0f,0);

		}

			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate(0,3.0f,0);
			}



		

	}



	void OnTriggerEnter (Collider colider)
	{
		var stateInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo (0);
		bool isJump = stateInfo.IsName("Base Layer.JUMP00");
		bool isSlide = stateInfo.IsName("Base Layer.SLIDE00");
		bool isRun = stateInfo.IsName("Base Layer.RUN00_F");

		bool isHigh = colider.CompareTag("High");
		bool isLow = colider.CompareTag("Low");
		bool isBarrier = colider.CompareTag ("barrier");
		bool isGoal = colider.CompareTag ("goal");

		if( (isRun == true && isGoal == false) ||
		    (isJump == true && isHigh == true) ||
		    (isSlide == true && isLow == true) ||
		    (isBarrier == true))
		   {
			animator.SetBool ("DEAD", true);
			speed = 0;

			//6 UI
			GameObject.Find("Canvas").GetComponent<UIscript> ().Gameover();

		}
		if(isGoal == true){
			animator.SetBool ("WIN", true);
			speed = 0;

			//6 UI
			GameObject.Find("Canvas").GetComponent<UIscript> ().Goal();
		}
	}



}
