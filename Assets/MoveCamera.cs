using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    private float speed = 2.0f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime);
    }
}
