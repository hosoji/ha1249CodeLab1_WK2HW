using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PathFollowingScript : MonoBehaviour {

	public Vector2[] path;
	public float speed;
	public float maxSpeed;
	public float target;

	public int currentPos = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float dist = Vector2.Distance (path [currentPos], transform.position);

		if (Input.GetButton("Space")){
			Move (speed);
		}

		if (Input.GetButton("LShift")){
			Move (maxSpeed);
		}
			
		if (dist <= target){
			currentPos++;
		}

		if (currentPos >= path.Length) {
			//currentPos = 0;
			Debug.Log ("YOU WIN!");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

//		Debug.Log ("Distance = " + dist);
		
	}
		void Move(float speed ){
		transform.position = Vector2.MoveTowards(transform.position, path[currentPos], Time.deltaTime * speed);
	}
}
