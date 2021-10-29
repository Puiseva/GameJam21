using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    bool gameIsPaused = false;
    public GameObject uiPauseButton;
    public GameObject uiPauseText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetButtonDown("Cancel") && gameIsPaused == false) // This pauses the game, since the game is not already paused, "Cancel" = Esc
            {
                uiPauseButton.SetActive(true); // Canvas Button object to "QUIT" set to visible
                uiPauseText.SetActive(true); // Canvas Text object that says "PAUSED" set to visible
                Time.timeScale = 0; // This pauses the game by practically setting the passage speed of time to zero
                                    // Updates still happen and buttons work but since no time passes, nothing happens
                gameIsPaused = true; // Set the boolean to let the code know the game is PAUSED
            }
            else if (Input.GetButtonDown("Cancel") && gameIsPaused == true) // This unpauses the game, since it is already paused,  "Cancel" = Esc
            {
                uiPauseButton.SetActive(false); // Hides the Canvas Button object "QUIT"
                uiPauseText.SetActive(false); // Hides the Canvas Text object that says "PAUSED"
                Time.timeScale = 1; // This unpauses the game by practically setting the passage speed of time to one (normal)
                                    // The passage of time stops being... convoluted
                gameIsPaused = false; // Set the boolean to let the code know the game is PAUSED NO LONGER
            }
        
    }*/
}
