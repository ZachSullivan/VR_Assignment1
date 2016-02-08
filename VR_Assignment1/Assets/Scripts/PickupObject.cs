using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour
{

    public Camera mainCam;

    GameObject carriedObject;

    public bool isCarrying = false;

    //Distance a held object should be from the camera
    public float dis = 3;

    //Smoothing value applied to held object movement (Higher = sharper movement)
    public float smooth = 3;

    // Use this for initialization
    void Start()
    {
        mainCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
            Screen.lockCursor = false;
        else
            Screen.lockCursor = true;

        //Check if the user is currently holding an object
        if (isCarrying)
        {
            CarryObject(carriedObject);
            CheckDrop();
        }
        else
        {
            ObjectPickup();
        }

    }

    void CarryObject(GameObject obj)
    {

        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.position = Vector3.Lerp(obj.transform.position, mainCam.transform.position + mainCam.transform.forward * dis, Time.deltaTime * smooth);
        obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, Quaternion.EulerAngles(0, 0, 0), Time.deltaTime * smooth);
        //obj.transform.LookAt(this.gameObject.transform);
    }

    void CheckDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DropObject();
        }
    }

    void DropObject()
    {
        isCarrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }

    void ObjectPickup()
    {

        //User must press E key to interact with object
        if (Input.GetKeyDown(KeyCode.E))
        {

            //Obtain the center point of the screen
            int screenX = Screen.width / 2;
            int screenY = Screen.height / 2;

            //Cast a ray from center of screen 
            Ray ray = mainCam.ScreenPointToRay(new Vector3(screenX, screenY));
            RaycastHit hit;

            //Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                //Ensure the object that is hit is interactable object (has interactable script attached)
                Interactable obj = hit.collider.GetComponent<Interactable>();

                //If the object is interactable, assign the current carried object to this
                if (obj != null)
                {
                    isCarrying = true;
                    carriedObject = obj.gameObject;
                }
            }
        }

    }

}
