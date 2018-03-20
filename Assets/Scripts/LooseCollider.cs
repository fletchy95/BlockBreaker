using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour 
{
	private LevelManager levelManager;
	public object levelSelected;
	public void OnTriggerEnter2D(Collider2D collider)
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelSelected = Application.loadedLevelName;
		Application.LoadLevel("Lose");
	}
	public void OnCollisionEnter2D (Collision2D collider)
	{}
}