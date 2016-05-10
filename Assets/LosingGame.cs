using UnityEngine;
using System.Collections;

public class LosingGame : MonoBehaviour {


	void Start()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Jeep")
		{
			Application.LoadLevel("GameOver");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Jeep")
		{
			Application.LoadLevel("GameOver");
		}

	}
}
