using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
	{
		//reset the static brick count before loading a new level
		Brick.breakableCount = 0;
	
		Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);		
	}

	public void LoadNextLevel()
	{
		//reset the static brick count before loading a new level
		Brick.breakableCount = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
			
	public void Quit()
	{
		Debug.Log("Game quit requested");
		Application.Quit();
	}
	
	public void BrickDestroyed()
	{
		if(Brick.breakableCount <= 0)
		{
			LoadNextLevel();
		}
	}
}
