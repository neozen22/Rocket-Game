using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debugger : MonoBehaviour
{

    CollisionHandler colHandler;
    LevelHandler levelHandler;
    // Start is called before the first frame update
    void Start()
    {
        
        colHandler = GetComponent<CollisionHandler>();
        levelHandler = GetComponent<LevelHandler>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleCollisions();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            levelHandler.debugMode = !levelHandler.debugMode;
            Debug.Log("Debug = " + levelHandler.debugMode.ToString());
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
    int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    
    int nextLevelIndex = 0;
    if (currentLevelIndex >= SceneManager.sceneCountInBuildSettings - 1) 
    {
        Debug.Log("sj");
        currentLevelIndex = 0;
        nextLevelIndex = 0;
    }
    else
    {
        Debug.Log(currentLevelIndex);
        Debug.Log(nextLevelIndex);
        nextLevelIndex = currentLevelIndex + 1;
    }
    SceneManager.LoadScene(nextLevelIndex);

    }

    void ToggleCollisions()
    {
        colHandler.collisionEnabled ^= true;
        Debug.Log("Collision Handler is " + colHandler.collisionEnabled.ToString());
    }
}
