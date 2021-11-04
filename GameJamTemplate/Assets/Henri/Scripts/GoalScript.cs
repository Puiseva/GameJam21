using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public int score;
    public GameObject exitDoor;
    public static GoalScript instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 1;

        if (score == 20)
        {
            Destroy(exitDoor);
        }

    }

}
