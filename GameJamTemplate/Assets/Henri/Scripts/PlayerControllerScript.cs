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
        /*/
        //ETEEN & TAAKSE LIIKE
        float ver = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * ver * speed * Time.deltaTime,Space.World);

        //VASEN & OIKEA LIIKE
        float hor = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hor * speed * Time.deltaTime,Space.World);
        */


        /*/
         //KOKEILU LIIKKUMISELLE
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }
        */

        //VER JA HOR KATSOMINEN
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }

        //45 ASTE KATSOMINEN

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 45, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, -45, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 135, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, -135, 0);
        }

        /*/
        //PELAAJAN ROTAATIO
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        */
    }

    private void FixedUpdate()
    {
        float ver = Input.GetAxisRaw("Vertical");
        float hor = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(hor, 0.0f, ver);
        movement.Normalize();


        myRB.velocity = movement * speed;

        if (hor != 0  || ver != 0)
        {
            speed += Time.deltaTime * 20;
            if (speed >= 10f)
            {
                speed = 10f;
            }
        }

        else if (hor == 0 || ver == 0)
        {
            speed = 5f;
        }
    }


    //void FixedUpdate()
    //{
        //VAIHTOEHTOINEN KOODI LIIKKEELLE
        //PELAAJAN LIIKE
        //float hor = Input.GetAxis("Horizontal");
        //float ver = Input.GetAxis("Vertical");
        //myRB.AddForce(new Vector3(hor * speed, 0, ver * speed));
    //}
}
