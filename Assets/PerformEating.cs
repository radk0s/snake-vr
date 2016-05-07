using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PerformEating : MonoBehaviour
{
    private Text eatenText;
    private MoveCamera cameraBehaviour;
    private int eatenCnt;
    private Vector3[] worldBounds;

    void Start()
    {
        cameraBehaviour = GameObject.Find("CardboardMain").GetComponent<MoveCamera>();

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

    void OnTriggerEnter(Collider other)
    {
        //eating
        if (other.tag == "Food")
        {
            Vector3 position = new Vector3(Random.Range(worldBounds[0].x, worldBounds[1].x), other.gameObject.transform.position.y, Random.Range(worldBounds[0].z, worldBounds[1].z));
            other.gameObject.transform.position = position; 
			Vector3 rotation = new Vector3(other.gameObject.transform.rotation.x, Random.Range(0, 360), other.gameObject.transform.rotation.z);
			other.gameObject.transform.eulerAngles = rotation;

            eatenCnt++;
            eatenText.text = eatenCnt.ToString();

            cameraBehaviour.Accelarate();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "World")
        {
            Application.LoadLevel("GameOver");
        }
        
    }
}
