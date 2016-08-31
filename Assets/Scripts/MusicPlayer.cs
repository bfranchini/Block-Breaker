using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

private static MusicPlayer instance = null;

void Awake()
{
        //we only want one instance of the MusicPlayer object throughout the life of the game
        if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
            DontDestroyOnLoad(gameObject);
		}		
}
	
	// Update is called once per frame
	void Update () {
	
	}
}
