using UnityEngine;
using System.Collections;

public class SnakeBodyBehavior : MonoBehaviour
{
    private const string SEGMENT_NAME = "Segment (#)";
    private GameObject snakeHead;

    void Start()
    {
        snakeHead = GameObject.Find("Snake head");
    }

    void Update ()
    {
        Vector3 headPosition = Camera.main.transform.position;

        Transform [] children = gameObject.GetComponentsInChildren<Transform>();

        //0th element of array is snake body (parent)
        //1st is a first segment - it should folow the head
        Vector3 firstPosition = children[1].position;
        Vector3 offset = (headPosition - firstPosition);
        offset.y = 0f;
        float distance = offset.magnitude;
        print(distance);
        children[1].Translate(offset);

        //the rest of segments should follow the presecutor
        for (int i = children.Length - 1; i >= 2; i--)
        {
            Vector3 currentPosition = children[i].position;
            Vector3 presecutorPosition = children[i - 1].position;
            offset = (presecutorPosition - currentPosition).normalized * distance;

            children[i].Translate(offset);
        }


    }

    public void AddSegment()
    {
        //create new segment on the line between 2 last segments
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();

        Vector3 lastPosition = children[children.Length - 1].position;
        Vector3 second2LastPosition = children[children.Length - 2].position;
        Vector3 newPosition = lastPosition + lastPosition - second2LastPosition;

        Transform newSegment = (Transform) Instantiate(children[children.Length - 1], newPosition, Quaternion.identity);
        newSegment.parent = gameObject.transform;
        newSegment.name = SEGMENT_NAME.Replace("#", (children.Length - 1).ToString());
    }
}
