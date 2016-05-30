using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    private float speed = 2.5f;
    private const float accelaration = 0.1f;
    private const float maxSpeed = 10f;
    private GameObject snakeHead;
    private float initialHeadY;

    void Start()
    {
        snakeHead = GameObject.Find("Snake head");
        initialHeadY = snakeHead.transform.position.y;
    }

	void Update ()
    {
        Vector3 offset = Camera.main.transform.forward;
        offset.y = 0;
        offset.Normalize();
        offset *= speed * Time.deltaTime;
        transform.Translate(offset);

        Vector3 headRotation = new Vector3(0f, Camera.main.transform.eulerAngles.y, 0f);
        snakeHead.transform.eulerAngles = headRotation;
        Vector3 headPosition = new Vector3(snakeHead.transform.position.x, initialHeadY, snakeHead.transform.position.z);
        snakeHead.transform.position = headPosition;
    }

    public void Accelarate()
    {
        if(speed < maxSpeed) speed += accelaration;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void Stop()
    {
        speed = 0f;
    }
}
