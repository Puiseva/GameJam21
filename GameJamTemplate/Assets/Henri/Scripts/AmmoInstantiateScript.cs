using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInstantiateScript : MonoBehaviour
{

    public GameObject myAmmo;
    public GameObject myDoughnut;
    public GameObject myMelee;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameObject bullet;
            bullet = Instantiate(myAmmo, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 250f);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(myDoughnut, transform.position, transform.rotation);
        }

        if(Input.GetButtonDown("Fire3"))
        {
            Instantiate(myMelee, transform.position, transform.rotation);
        }
    }
}
