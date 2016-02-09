using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class moveMe : MonoBehaviour {
	Rigidbody myBody;
	public List<Vector3> targetpositions = new List<Vector3> ();
	public Vector3 travelAreaOrigin;
	public float travelAreaWidth;
	public float travelAreaDepth;
    public float maxHeight = 7.0f;

    public float arrivalThres = 1.0f;

    public bool canMove = true;

    public float speed;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody> ();

        if (canMove)
            targetpositions.Add(new Vector3(Random.Range(travelAreaOrigin.x - travelAreaWidth, travelAreaOrigin.z + travelAreaWidth), maxHeight, Random.Range(travelAreaOrigin.z - travelAreaDepth, travelAreaOrigin.z + travelAreaDepth)));
        else
            targetpositions.Add(this.transform.position);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector3 dVec = new Vector3 (targetpositions [0].x - transform.position.x, targetpositions [0].y - transform.position.y, targetpositions [0].z - transform.position.z);
		Vector3.Normalize (dVec);
        
        myBody.AddForce (dVec.x * speed, 9.8f*(dVec.y*3),dVec.z * speed);
        
        if ( Vector3.Distance( targetpositions[0], transform.position ) < arrivalThres)
        {
			targetpositions.Add ( new Vector3( Random.Range(travelAreaOrigin.x-travelAreaWidth,travelAreaOrigin.z+travelAreaWidth), maxHeight, Random.Range (travelAreaOrigin.z-travelAreaDepth,travelAreaOrigin.z+travelAreaDepth) ));
			targetpositions.Remove (targetpositions[0]);
		}
	}
}
