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
        isBreakable = (tag == "Breakable" || tag == "1Up");
		
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
		if(isBreakable)
        {
            //we want to spawn the audio source where the camera is so we can actually hear the clip playing
            AudioSource.PlayClipAtPoint(crack, Camera.main.transform.position); 
            HandleHits();
        }			
	}
	
	void HandleHits()
	{
		timesHit++;
		var maxHits = hitSprites.Length + 1;
		
		if(timesHit >= maxHits)
		{
			breakableCount--;

            if (tag == "1Up")
                Player.CurrentLives++;

            UI.UpdateLives(true);

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
		brickSmoke.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites()
	{
		var spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];			
		else
			Debug.LogError("Brick Sprite is missing");
	}
	
	//TODO: remove this method onece we actually win
	void SimulateWin()
	{
		levelManager.LoadNextLevel();
	}	
}
