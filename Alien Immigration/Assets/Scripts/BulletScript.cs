using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour {


	public GameObject motherCraft;
	public ForceMode2D force;
	Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce (transform.up, force);

	}

	public void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "immigrant") {
			Destroy (gameObject);
			Camera.main.GetComponent<ScreenShakeScript> ().Shaker(0.1f); 


			if (coll.gameObject == motherCraft) {
				Destroy (coll.gameObject);
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
				Debug.Log ("TRY AGAIN!");
			} else {
				Destroy (coll.gameObject);
				Debug.Log ("OUCH!");

			}

		}
	}
}
