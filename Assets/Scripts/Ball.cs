using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	private bool ballBegan = false;
	void Start () 
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	void Update () 
	{
		if(!hasStarted)
		{
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}
		if(Input.GetMouseButton(0) && !ballBegan)
		{
			ballBegan = true;
			hasStarted = true;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f , 10f);
		}
	}
	public void OnCollisionEnter2D (Collision2D collider)
	{
		if(hasStarted)
		{
			Vector2 tweak = new Vector2(Random.Range (-.5f , .5f) , Random.Range (-.1f , .2f));
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
