using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBallScript : MonoBehaviour
{

    public Rigidbody myRB;

    public float ballSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        myRB.AddForce(new Vector3(-vertical * ballSpeed, 0f, horizontal * ballSpeed));
    }
}
