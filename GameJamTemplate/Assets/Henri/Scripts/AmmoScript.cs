using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{

    public GameObject wallExplosion;
    public GameObject enemyExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Instantiate(wallExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
