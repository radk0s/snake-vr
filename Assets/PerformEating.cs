using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PerformEating : MonoBehaviour
{
    private Text eatenText;
    private int eatenCnt;
    private const int FOOD_CNT = 5;

    // Use this for initialization
    void Start()
    {
        eatenCnt = 0;
        eatenText = GameObject.Find("/HUD/Eaten").GetComponent<Text>();
    }

    void Update() {
    }

    void OnTriggerEnter(Collider other)
    {
        //eating
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            eatenCnt++;
            eatenText.text = eatenCnt.ToString();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "World")
        {
            print("You loose");
        }
        
    }
}
