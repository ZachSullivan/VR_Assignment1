using UnityEngine;
using System.Collections;

public class FixedShadow : MonoBehaviour {

    Quaternion fixedRot;

	// Use this for initialization
	void Start () {
        fixedRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = fixedRot;
	}
}
