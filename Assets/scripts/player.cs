using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private bool jumpKeyWasPressed = false;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    public Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private int superJumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // Fixed update called once every physics update
    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(
            horizontalInput,
            rigidBodyComponent.velocity.y,
            rigidBodyComponent.velocity.z);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = 5;
            if (superJumpCount > 0)
            {
                jumpPower *= 2;
                superJumpCount--;
            }
            rigidBodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            superJumpCount++;
        }
    }

}
