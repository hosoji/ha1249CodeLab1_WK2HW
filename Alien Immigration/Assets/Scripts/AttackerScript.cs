using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerScript : MonoBehaviour {

	public Vector2 posMin;
	public Vector2 posMax;
	public float speed;
	public float bulletWaitFactor;

	float start;
	float end;

	static float t = 1f;

	GameObject bullet;

	// Use this for initialization
	void Start () {
		bullet = GameObject.Find ("Projectile");
		InvokeRepeating ("ShootBullet", 1f, bulletWaitFactor);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector2(Mathf.Lerp(start, end, t), -3.9f);

		t += 1f * Time.deltaTime;

		if (t > 1.0f) {
			PositionUpdate();
		}
		
	}

	void PositionUpdate(){

		start = transform.position.x;
		end = Random.Range (posMin.x, posMax.x);
		t = 0f;
	}

	void ShootBullet(){
		Instantiate (bullet, transform.position, Quaternion.identity);
	}
		
}
