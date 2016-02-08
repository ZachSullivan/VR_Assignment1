using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour
{
    private bool clicked;
    public Material defaultMaterial;
    public Material glowMaterial;
    public PickupObject pickup;
    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material = new Material(defaultMaterial);
        pickup = GameObject.Find("Player").GetComponent<PickupObject>();
        clicked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }

    void OnMouseExit() {
        //GameObject.Find("SphereDesc").GetComponent<MeshRenderer>().enabled = false;
    }

    void OnMouseOver()
    {

        //GameObject.Find("SphereDesc").GetComponent<MeshRenderer>().enabled = true;

        if (pickup.isCarrying)
        {
            GetComponent<Renderer>().material = defaultMaterial;
        }
        else
        {
            GetComponent<Renderer>().material = glowMaterial;
        }

    }

}
