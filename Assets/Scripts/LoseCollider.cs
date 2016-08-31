using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
    public Ball ball; //used to instantiate new balls on top of paddle

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ball")
        {
            Player.CurrentLives--;

            print("Current lives: " + Player.CurrentLives);

            //game over!
            if (Player.CurrentLives <= 0)
            {
                FindObjectOfType<Player>().InitializePlayer();

                FindObjectOfType<LevelManager>().LoadLevel("Lose");
            }

            StartCoroutine(SpawnNewBall(collider));
        }
        else
        {
            //destroy whatever just hit us
            Destroy(collider.gameObject);
        }
    }

    IEnumerator SpawnNewBall(Collider2D collider)
    {
        //TODO: Play losing sound effect and wait for length of sound effect

        yield return new WaitForSeconds(.5f);
        
        var paddlePos = FindObjectOfType<Paddle>().transform.position;

        //add offset to y-axis so ball is on top of paddle when it's spawned
        paddlePos.y += Ball.BallPaddleYOffset;
               
        //spawn new ball and put it on top of paddle
        ball = (Ball)Instantiate(ball, paddlePos, Quaternion.identity);

        //destroy ball
        Destroy(collider.gameObject);
    }
}
