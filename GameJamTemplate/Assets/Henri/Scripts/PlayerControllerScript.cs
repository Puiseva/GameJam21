using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public float speed = 5f;
    public float rotateSpeed = 2f;

    public Rigidbody myRB;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //ETEEN & TAAKSE LIIKE
        float ver = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * ver * speed * Time.deltaTime,Space.World);

        //VASEN & OIKEA LIIKE
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hor * speed * Time.deltaTime,Space.World);

        //PELAAJAN ROTAATIO
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

    }

    void FixedUpdate()
    {
        //VAIHTOEHTOINEN KOODI LIIKKEELLE
        //PELAAJAN LIIKE
        //float hor = Input.GetAxis("Horizontal");
        //float ver = Input.GetAxis("Vertical");
        //myRB.AddForce(new Vector3(hor * speed, 0, ver * speed));
    }
}
