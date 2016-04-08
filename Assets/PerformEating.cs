using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PerformEating : MonoBehaviour {
    private Text eatenText;
    private int eatenCnt;

    // Use this for initialization
    void Start () {
        eatenCnt = 0;
        eatenText = GameObject.Find("/HUD/Eaten").GetComponent<Text>();
        eatenText.text = eatenCnt.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        
        print("Collision detected with trigger object " + other.name);
    }
}
