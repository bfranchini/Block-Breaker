using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;		
	private LevelManager levelManager;
	private bool isBreakable;

	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		
		//keep track of breakable bricks
		if(isBreakable)		
			breakableCount++;
			
		timesHit = 0;		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		//comment while testing			
	//	AudioSource.PlayClipAtPoint(crack, transform.position);
				 	
		if(isBreakable)
			HandleHits();
	}
	
	void HandleHits()
	{
		timesHit++;
		var maxHits = hitSprites.Length + 1;
		
		if(timesHit >= maxHits)
		{
			breakableCount--;
			levelManager.BrickDestroyed();
			
			generateSmoke();
			
			//destroy this brick
			Destroy(gameObject);																				
		}
		else
		{
			LoadSprites();
		}			
	}
	
	void generateSmoke()
	{
		//create smoke cloud at the location of this brick
		GameObject brickSmoke = (GameObject)Instantiate(smoke, transform.position,Quaternion.identity);
		
		//set color of smoke to match this brick's color
		brickSmoke.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites()
	{
		var spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex] != null)
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];			
		else
			Debug.LogError("Brick Sprite is missing");
	}
	
	//TODO: remove this method onece we actually win
	void SimulateWin()
	{
		levelManager.LoadNextLevel();
	}	
}
