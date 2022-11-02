using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    private bool JumpKeyWasPressed;
    private float HorizontalInput;
    private Rigidbody rigidbodyComponent;
    [SerializeField] private float speed = 5;

    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();

    
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpKeyWasPressed = true;
        }

        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.Translate(dir * speed * Time.deltaTime);


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movmenetDirection = new Vector3(horizontalInput, 0, verticalInput);
        movmenetDirection.Normalize();

        transform.Translate(movmenetDirection * speed * Time.deltaTime, Space.World);

        if (movmenetDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movmenetDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }



    }

    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(HorizontalInput, rigidbodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }

        if (JumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            JumpKeyWasPressed = false;
        }

    }
}
