using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour
{

    public float movementSpeed;
    public float turningSpeed;
    //public float turretTurningSpeed;
    public float shootingCooldown;
    public float detectRange;
    public float stoppingRange;
    public float switchTargetRange;
    public float switchDistance;

    public float AIDelay;
    public float AIDelayHit;

    //public Transform Turret;
    public Transform muzzle;
   // public GameObject projectile;

    public AudioSource audioSource;

    public string stringState;

    private Rigidbody rb;
    private float t;
    private float AIt;

    private GameObject targetObject;
    private Vector3 target;

    private int obstacleMask;

    private enum State { forward, left, right, back, stop, beenhit };
    private State state;
    private State nextState;

    public float pushForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = 0f;
        AIt = 0f;
        obstacleMask = LayerMask.GetMask("Obstacle");
        state = State.forward;
        nextState = State.forward;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        t -= Time.deltaTime;

        Vector3 currentRotation = rb.rotation.eulerAngles;
        rb.rotation = Quaternion.Euler(0f, currentRotation.y, 0f);

        if (Vector3.Distance(transform.position, target) < switchTargetRange)
        {
            float randomx = Random.Range(-switchDistance, switchDistance);
            float randomz = Random.Range(-switchDistance, switchDistance);

            target += new Vector3(randomx, 0f, randomz);
        }

        //etsi pelaaja
        if (targetObject != null)
        {
            if (Vector3.Distance(transform.position, targetObject.transform.position) < detectRange)
            {
                if (!Physics.Linecast(transform.position, targetObject.transform.position, obstacleMask))
                {
                    target = targetObject.transform.position;

                    //shooty-shoot
                   /* if (t < 0)
                    {
                        audioSource.Play();
                        GameObject proj = Instantiate(projectile, muzzle.position, muzzle.rotation);
                        proj.GetComponent<Projectile>().shooterTag = tag;
                        t = shootingCooldown;

                    }
                    */


                    if (Vector3.Distance(target, transform.position) < stoppingRange)
                    {
                        nextState = State.stop;

                    }

                }
            }
            // target = targetObject.transform.position;

        }
        else
        {
            targetObject = GameObject.FindGameObjectWithTag("Player");


        }

        Debug.DrawLine(target, target + new Vector3(0f, 5f, 0f), Color.green);


        float angle = Vector3.SignedAngle(transform.forward, target - transform.position, Vector3.up);

        if (AIt < 0)
        {
            state = nextState;
            AIt = AIDelay;
        }
        else
        {
            AIt -= Time.deltaTime;
        }

        //tilakone
        if (state == State.forward)
        {
            stringState = "forward";
            if (angle < 0)
            {
                Turning(-1f);
            }
            else if (angle > 0)
            {
                Turning(1f);
            }

            if (Mathf.Abs(angle) < 90)
            {
                Move(1f);

            }
        }
        if (state == State.left)
        {
            stringState = "left";
            Turning(-1f);
            Move(1f);

        }
        if (state == State.right)
        {
            stringState = "right";
            Turning(1f);
            Move(1f);

        }
        if (state == State.back)
        {
            stringState = "back";
            Move(-1f);
            nextState = State.forward;

        }
        if (state == State.stop)
        {
            stringState = "stop";
            Move(0f);
            nextState = State.forward;
        }


        /* Vector3 targetDirection = target - Turret.position;
        targetDirection.y = 0f;
       Vector3 turningDirection = Vector3.RotateTowards(Turret.forward, targetDirection, turretTurningSpeed * Time.deltaTime, 0f);
        Turret.rotation = Quaternion.LookRotation(turningDirection);*/



        //liiku kohti




    }

    private void Update()
    {
      if (state == State.beenhit)
        {
            stringState = "beenhit";
          //  Move(0f);
          //  Turning(0f);
        }
    }

    private void Move(float input)
    {
        if (state != State.beenhit)
        {
            Vector3 movement = transform.forward * input * movementSpeed;
            rb.velocity = movement;
        }
    }

    private void Turning(float input)
    {
        if (state != State.beenhit)
        {
            Vector3 turning = Vector3.up * input * turningSpeed;
            rb.angularVelocity = turning;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && (state == State.beenhit))
        {
         //   print("osuma!");
          //  Destroy(other.gameObject);
          //  Destroy(gameObject);
           /* // Calculate Angle Between the collision point and the player
            Vector3 dir = other.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * pushForce);*/
        }
               


        if (!other.gameObject.CompareTag("Obstacle") && !other.gameObject.CompareTag("Wall"))
        {
            return;
        }

        RaycastHit leftHit;
        RaycastHit rightHit;
        float leftLength = 0f;
        float rightLength = 0f;

        if (Physics.Raycast(transform.position, transform.forward + transform.right * -1, out leftHit, Mathf.Infinity, obstacleMask))
        {
            leftLength = leftHit.distance;
        }
        if (Physics.Raycast(transform.position, transform.forward + transform.right, out rightHit, Mathf.Infinity, obstacleMask))
        {
            rightLength = rightHit.distance;
        }
        if (leftLength > rightLength)
        {
            state = State.left;
            target = leftHit.point;
        }
        else
        {
            state = State.right;
            target = rightHit.point;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        nextState = State.forward;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle") && !collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("PlayerAmmo") && (state != State.beenhit))
        {
            return;
        }
        else if (collision.gameObject.CompareTag("PlayerAmmo"))
        {
            state = State.beenhit;
            nextState = State.stop;
            stringState = "beenhit";
            Move(0f);
            Turning(0f);
            AIt = AIDelayHit;
            print("collisionenter osuma!");
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[1].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(dir * pushForce);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            print("osuma!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            state = State.back;
        }
    }
}
