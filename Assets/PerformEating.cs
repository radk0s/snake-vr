using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PerformEating : MonoBehaviour
{
    private Text eatenText;
    private int eatenCnt;
    private Vector3[] worldBounds;

    // Use this for initialization
    void Start()
    {
        eatenCnt = 0;
        eatenText = GameObject.Find("CardboardMain/Head/HUD/Eaten").GetComponent<Text>();

        Renderer worldRenderer = GameObject.FindGameObjectWithTag("World").GetComponent<Renderer>();
        Vector3 worldSize = worldRenderer.bounds.size;
        Vector3 worldPos = worldRenderer.transform.position;
        const float worldFill = 0.98f;
        worldBounds = new Vector3[2];
        worldBounds[0] = new Vector3(worldPos.x - worldSize.x * worldFill / 2, 0, worldPos.z - worldSize.z * worldFill / 2);
        worldBounds[1] = new Vector3(worldPos.x + worldSize.x * worldFill / 2, 0, worldPos.z + worldSize.z * worldFill / 2);
    }

    void Update() {
    }

    void OnTriggerEnter(Collider other)
    {
        //eating
        if (other.tag == "Food")
        {
            //Destroy(other.gameObject);
            Vector3 position = new Vector3(Random.Range(worldBounds[0].x, worldBounds[1].x), other.gameObject.transform.position.y, Random.Range(worldBounds[0].z, worldBounds[1].z));
            other.gameObject.transform.position = position; 

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
