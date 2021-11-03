using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoughnutScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        /*/
        if (other.gameObject.tag == "P")
        {
            Instantiate(wallExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        */
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
