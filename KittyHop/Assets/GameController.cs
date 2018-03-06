using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static GameController instance;
    public float restartDelay = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }


    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
    /// <summary>
    /// restarts the level when player dies
    /// </summary>
    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        Invoke("RestartLevel", restartDelay);
    }

    public void PlayerDrowned(GameObject player)
    {
        Invoke("RestartLevel", restartDelay);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
