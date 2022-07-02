using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMusk;
    public AudioSource stepAudio;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float groundDistance = 0.1f;
    private float stepTimer = 0.5f;
    private float runTimer = 0.3f;
    private float stepTimerDown = 0.5f;
    private float runTimerDown = 0.3f;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMusk);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");        

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (x != 0 || z != 0)
        {
            if (Input.GetKey("left shift"))
            {
                speed = 12f;
                RunSound();
            }
            else
            {
                speed = 5f;
                StepSounds();
            }            
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }     
    }

    public void StepSounds()
    {
        if (stepTimerDown > 0)
        {
            stepTimerDown -= Time.deltaTime;
        }
        if (stepTimerDown < 0)
        {
            stepAudio.Play();
            stepTimerDown = stepTimer;
        }
    }

    public void RunSound()
    {
        if (runTimerDown > 0)
        {
            runTimerDown -= Time.deltaTime;
        }
        if (runTimerDown < 0)
        {
            stepAudio.Play();
            runTimerDown = runTimer;
        }
    }
}
