using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
    private float speed = 2.5f;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = Camera.main.transform.forward * speed * Time.deltaTime;
        offset.y = 0;
        transform.Translate(offset);
    }

}
