using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    private float speed = 2.5f;
    private const float accelaration = 0.1f;
    private const float maxSpeed = 7f;
    
	void Update ()
    {
        Vector3 offset = Camera.main.transform.forward * speed * Time.deltaTime;
        offset.y = 0;
        transform.Translate(offset);

        //move snake body

    }

    public void Accelarate()
    {
        if(speed < maxSpeed) speed += accelaration;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
