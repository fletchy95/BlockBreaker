using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{
	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public static int brickCount = 0;
	private bool isBreakable;
	public AudioClip crack;
	public GameObject smoke;
	// Use this for initialization
	void Start () 
	{
		isBreakable  = (this.tag == "Breakable");
		// keep track of breakable bricks
		if(isBreakable)
		{
			brickCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {}
	public void OnCollisionEnter2D (Collision2D collider)
	{
		AudioSource.PlayClipAtPoint(crack , transform.position , 0.333f);
		if(isBreakable)
		{
			HandleHits();
		}
	}

	void HandleHits()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits)
		{
			Destroyer();
		}
		else
		{
			LoadSprites();
		}
	}
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		if(this.GetComponent<SpriteRenderer>().sprite == null)
		{
			Destroyer ();
		}
	}
	private void Destroyer()
	{
		brickCount--;
		levelManager.BrickDestroyed();
		GameObject smokePuff = Instantiate(smoke , gameObject.transform.position , Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
		Destroy(gameObject);
	}
}