using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float dashSpeed = 200f;
    public float dashDuration = 0.2f;
    public float mouseSensitivity = 100f;

    private Vector3 velocity;
    private bool isGrounded;
    private float dashTime;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        
        transform.rotation *= Quaternion.Euler(0f, mouseX, 0f);
        Vector3 move = transform.right * x + transform.forward * z;
        move = Vector3.ProjectOnPlane(move, Vector3.up);
        move.y = 0f;

        if (Input.GetButtonDown("Fire3"))
        {
            dashTime = dashDuration;
            move *= dashSpeed;
        }

        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime;
            controller.Move(move * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
    }
}
