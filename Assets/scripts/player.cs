using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private bool jumpKeyWasPressed = false;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    public Transform groundCheckTransform = null;
    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // Fixed update called once every physics update
    private void FixedUpdate(){
        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1){
            return;
        }

        if(jumpKeyWasPressed){
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        rigidBodyComponent.velocity = new Vector3(
            horizontalInput, 
            rigidBodyComponent.velocity.y, 
            rigidBodyComponent.velocity.z);
    }

}
