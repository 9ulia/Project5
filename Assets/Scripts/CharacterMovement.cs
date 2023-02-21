using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    [SerializeField] private CharacterController player;

    [SerializeField] private CharacterController cameraController;
    [SerializeField] private Transform cameraTransform;

    public float moveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform;
        Vector3 _velocity;
        _velocity = new Vector3(0.0f, -0.1f, 0.0f);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = (playerTransform.right * x) + (playerTransform.forward * z); 
        playerTransform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 2.5f, 0));
        //cameraTransform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -2.5f, Input.GetAxis("Mouse X") * 2.5f, 0));
        // cameraTransform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 2.5f, Space.Self);
        // cameraTransform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * -2.5f, Space.Self);
        //cameraTransform.rotation = new Quaternion(cameraTransform.rotation.x, cameraTransform.rotation.y, 0, 0);
        
        cameraTransform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -2.5f, Input.GetAxis("Mouse X") * 2.5f, 0));
        cameraTransform.eulerAngles = new Vector3(cameraTransform.eulerAngles.x, cameraTransform.eulerAngles.y, 0);
        transform.eulerAngles =
            new Vector3(transform.eulerAngles.x, cameraTransform.eulerAngles.y, transform.eulerAngles.x);

        player.Move(movement * moveSpeed);
        cameraController.Move(movement * moveSpeed);
        player.Move(_velocity);

    }
}
