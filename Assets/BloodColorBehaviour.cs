using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodColorBehaviour : MonoBehaviour {
    private bool bleeding = false;
    private Image bloodImage;

	void Start () {
        bloodImage = GameObject.Find("CardboardMain/Head/HUD/Blood").GetComponent<Image>();
    }
	
	void Update () {
        if (bleeding)
        {
            Color color = bloodImage.color;
            if(color.a >= 0.95f) {
                Application.LoadLevel("GameOver");
            } else {
                color.a += 0.05f;
                bloodImage.color = color;
            }
        }
	}

    public void StartBleeding()
    {
        bleeding = true;
    }
}
