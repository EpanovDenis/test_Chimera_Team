using UnityEngine;

public class Shell : MonoBehaviour
{    
    public Transform arm;
    public Transform respawn;
    public AudioSource hitBall;
    public float forceThrow = 10f;
    public float speedRespawn = 0.5f;
    public static int currentChild;    
    
    Rigidbody myRigidbody;
    [HideInInspector] public bool flag = false;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();        
    }

    public void PickUp()
    {
        if (arm.childCount < 1)
        {
            transform.SetParent(arm);
            transform.position = arm.position;
            transform.rotation = arm.rotation;
            myRigidbody.isKinematic = true;
            flag = true;
        }
        else
        {
            Debug.Log("!!!");
        }
        
    }

    public void Put()
    {
        if (flag == true)
        {
            transform.parent = null;
            myRigidbody.isKinematic = false;
            myRigidbody.AddForce(transform.forward * 0.5f);
            flag = false;
        }
    }

    public void Throw()
    {
        if (flag == true)
        {
            transform.parent = null;
            myRigidbody.isKinematic = false;
            myRigidbody.AddForce(transform.forward * forceThrow * ScaleForceBar.currecnForce, ForceMode.Impulse);
            flag = false;
        }
    }

    public void Respawn()
    {        
        transform.position = Vector3.MoveTowards(transform.position, respawn.position,speedRespawn * Time.deltaTime);

        if (transform.position == respawn.position)
        {
            CollisionPlayer.flagRespawn = false;
        }
    }

    private void Update()
    {
        currentChild = arm.childCount;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Put();
        }        

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Throw();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            hitBall.Play();
        }        
    }
}
