using UnityEngine;
using System.Collections;

public class LosingGame : MonoBehaviour {


	void Start()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Snake body")
		{
			Application.LoadLevel("GameOver");
		}
	}
}
