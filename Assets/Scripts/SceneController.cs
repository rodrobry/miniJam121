using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        //Start game when space is pressed
        if (Input.GetButtonDown("Jump") && scene.buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }

        //Start game when space is pressed
        if (Input.GetButtonDown("Jump") && scene.buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }

        //Return to main menu when esc is pressed
        if (Input.GetButtonDown("Cancel") && scene.buildIndex != 0)
        {
            SceneManager.LoadScene(0);
        }

        //Jump to game over scene when player dies
        var player = GameObject.FindWithTag("Player");
        if (player == null  && scene.buildIndex == 2)
        {
            SceneManager.LoadScene(3);
        }

        //Restart game from game over scene if space is pressed
        if (Input.GetButtonDown("Jump")  && scene.buildIndex == 3)
        {
            SceneManager.LoadScene(2);
        }
    }

    public static void WinGame()
    {
        SceneManager.LoadScene(4);
    }

    public static void LoseGame()
    {
        SceneManager.LoadScene(3);
    }


}
