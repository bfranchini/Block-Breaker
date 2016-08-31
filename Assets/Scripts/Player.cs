using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private static Player instance = null;

    public static int CurrentLives;
    public int InitialLives;

    void Awake()
    {
        //we only want one instance of the player object throughout the life of the game
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

    // Use this for initialization
    void Start() {
        InitializePlayer();
    }

    // Update is called once per frame
    void Update() {

    }

    public void InitializePlayer()
    {
        CurrentLives = InitialLives;
    }
}
