using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    //offset from center of paddle to make ball appear to be sitting on top of paddle.
    public static float BallPaddleYOffset =.363f;

    //used to lock ball position to paddle position at start of game or new life
    private Paddle paddle;	
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;    

	// Use this for initialization
	void Start () {
      
		paddle = FindObjectOfType<Paddle>();
	
		paddleToBallVector = transform.position - paddle.transform.position;		
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(!hasStarted)
		{
			//lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			//wait for a mouse press to launch
			if(Input.GetMouseButtonDown(0))
			{
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
		}			
	}
	
	public void OnCollisionEnter2D(Collision2D coll)
	{
		//adjust velocity by a small amount in the x and y directions to prevent "boring loops"
		var tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
			
		if(hasStarted)
		{
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;	
		}				
	}
}
