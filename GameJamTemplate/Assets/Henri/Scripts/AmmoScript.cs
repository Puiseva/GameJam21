using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

         Destroy(gameObject, 1f);
        //tagin avulla tuhoaa luodin "wall"
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
