using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInstantiateScript : MonoBehaviour
{

    public GameObject myAmmo;
    public GameObject myDoughnut;
    public GameObject myMelee;
    public GameObject myExplosion;

    public GameObject myGun;
    public GameObject myDecoy;
    public GameObject mySlash;
    public GameObject myGunPowder;

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
            bullet = Instantiate(myAmmo,myGun.transform.position,myGun.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
            Instantiate(myExplosion, myGunPowder.transform.position, myGun.transform.rotation);
            
        }

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject doughnut;
            doughnut = Instantiate(myDoughnut, myDecoy.transform.position, myDecoy.transform.rotation);
            doughnut.GetComponent<Rigidbody>().AddForce(transform.forward * 600f);
            Destroy(doughnut, 1f);

            //testi
        }

        if(Input.GetButtonDown("Fire2"))
        {
            GameObject melee;
            melee = Instantiate(myMelee,mySlash.transform.position,mySlash.transform.rotation);
            melee.transform.parent = mySlash.transform;
            Destroy(melee, 0.3f);
        }
    }
}
