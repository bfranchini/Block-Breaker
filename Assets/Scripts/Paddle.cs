using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour 
{	
	public bool autoPlay = false;
	public float paddleWitdthMin;
	public float paddleWidthMax;
	private Ball ball;   //used to track ball position during auto play
	
	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!autoPlay)
			MoveWithMouse();
		else
			AutoPlay();			
	}
	
	private void MoveWithMouse(){
		var paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
		
		var mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16f);
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, paddleWitdthMin, paddleWidthMax);

        transform.position = paddlePos;
	}
	
	private void AutoPlay(){
		var paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);	
		
		var ballPos = ball.transform.position;
		
		paddlePos.x = Mathf.Clamp(ballPos.x, paddleWitdthMin, paddleWidthMax);				
		
		this.transform.position = paddlePos;			
	}
}
