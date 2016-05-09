using UnityEngine;
using System.Collections;

public class SnakeBodyBehavior : MonoBehaviour
{
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
        children[1].Translate(offset);
        print("offset " + offset);

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
        print("new segment");
    }
}
