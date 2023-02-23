using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    // MOVEMENT
    [SerializeField] private CharacterController player;
    public float moveSpeed;
    
    // CAMERA MOVEMENT
    [SerializeField] private CharacterController cameraController;
    [SerializeField] private Transform cameraTransform;
    
    // AUDIO
    [SerializeField] private AudioClip stepSounds;
    private AudioSource _playerAs1;
    private float stepInterval = 0.0f;
    private bool _shutUp = true;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _playerAs1 = GetComponent<AudioSource>();
        _playerAs1.volume = 1f;
        _playerAs1.spatialBlend = 1f;
        _playerAs1.maxDistance = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = transform;
        Vector3 _velocity;
        _velocity = new Vector3(0.0f, -0.1f, 0.0f);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            _shutUp = false;
        }
        else
        {
            _shutUp = true;
        }

        Vector3 movement = (playerTransform.right * x) + (playerTransform.forward * z); 
        playerTransform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 2.5f, 0));

        cameraTransform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * -2.5f, Input.GetAxis("Mouse X") * 2.5f, 0));
        cameraTransform.eulerAngles = new Vector3(cameraTransform.eulerAngles.x, cameraTransform.eulerAngles.y, 0);
        transform.eulerAngles =
            new Vector3(transform.eulerAngles.x, cameraTransform.eulerAngles.y, transform.eulerAngles.x);

        player.Move(movement * moveSpeed);
        cameraController.Move(movement * moveSpeed);
        player.Move(_velocity);

        stepInterval += Time.deltaTime;

        if (stepInterval > 0.5f && !_shutUp)
        {
            _playerAs1.clip = stepSounds;
            _playerAs1.Play();
            stepInterval = 0.0f;
        }
        else if (_shutUp)
        {
            stepInterval = 0.0f;
        }

        // _playerAs1.clip = stepSounds;
        // _playerAs1.Play();

    }
}
