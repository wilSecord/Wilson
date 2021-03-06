using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public CircleCollider2D collider;
	public Rigidbody2D phys;
	public int jumpSpeed = 3;
	public int jumpNumber = 0;
	public int jumpMax = 1;
	public int moveSpeed = 1;

	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<CircleCollider2D>();
		phys = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		jump ();
		move ();
	}
	void jump(){
		if (Input.GetKey (KeyCode.W) && jumpNumber < jumpMax) {
			phys.velocity += Vector2.up * jumpSpeed;
			jumpNumber++;
		}
	}
	void move(){
		if (Input.GetKey (KeyCode.D)) {
			collider.sharedMaterial.friction = 0;
			phys.velocity += Vector2.right * moveSpeed;
		} else if (Input.GetKey (KeyCode.A)) {
			collider.sharedMaterial.friction = 0;
			phys.velocity += Vector2.left * moveSpeed;
		} else {
			collider.sharedMaterial.friction = 20;
		}
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Ground") {

			jumpNumber = 0;
		
		}

	}
}