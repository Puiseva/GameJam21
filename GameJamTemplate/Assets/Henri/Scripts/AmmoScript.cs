using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{

    public GameObject myExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Instantiate(myExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        

        //Destroy(gameObject, 1f);
        //tagin avulla tuhoaa luodin "wall"
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
