using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int speed = 5;
    public int jumpSpeed = 6;
    public int gravity = 20;
    public int mouseXSens = 5;
    public int mouseYSens = 5;

    public float camYViewRange = 60.0f;
    public float smooth = 7;

    bool isCrouching = false;

    float camYRot = 0;
    float adjustedCamYRot = 0;

    Vector3 moveDirection;

    CharacterController playerController;

    public Camera mainCam;
	// Use this for initialization
	void Start () {

        //Initiallize movement vector to zero on start
        moveDirection = Vector3.zero;

        playerController = GetComponent<CharacterController>();
        mainCam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        float camXRot = Input.GetAxis("Mouse X") * mouseXSens;
        transform.Rotate(0, camXRot, 0);

        
        camYRot -= Input.GetAxis("Mouse Y") * mouseYSens;
        camYRot = Mathf.Clamp(camYRot, -camYViewRange, camYViewRange);
        Camera.main.transform.localRotation = Quaternion.Euler(camYRot, 0, 0);

        if (playerController.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection * Time.deltaTime);
    }
}
