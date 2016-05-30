using UnityEngine;
using System.Collections;

public class MenuPointer : MonoBehaviour {
    private const string buttonTag = "Button";

    void OnTriggerEnter(Collider other)
    {
		if(other.tag == buttonTag)
        {
            AbstractButtonBehavior behaviour = other.gameObject.GetComponent<AbstractButtonBehavior>();
            behaviour.Select();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == buttonTag)
        {
            AbstractButtonBehavior behaviour = other.gameObject.GetComponent<AbstractButtonBehavior>();
            behaviour.Deselect();
        }
    }
}

public abstract class AbstractButtonBehavior : MonoBehaviour
{
    private bool selected = false;
    private float selectedAt;
    private float distanceToCamera;
    private const float selectionTime = 2.5f;
    private Color selectedColor = Color.white;
    private Color notSelectedColor = new Color(1.0f, 0.5f, 1.0f);
    private Vector3 initialScale;

    void Start()
    {
        distanceToCamera = 2.0f;
        initialScale = gameObject.transform.localScale;
    }

    void Update()
    {
        //rotate
        Vector3 rotation = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        gameObject.transform.eulerAngles = rotation;
        Vector3 position = Camera.main.transform.forward * distanceToCamera;
        position.y = gameObject.transform.position.y;
        gameObject.transform.position = position;


        if (selected)
        {
            float selectionTimeSoFar = Time.time - selectedAt;
            float scaleY = 1.0f - selectionTimeSoFar / selectionTime;
            Vector3 currentScale = new Vector3(initialScale.x * (scaleY >= 0 ? scaleY : 0), initialScale.y, initialScale.z);
            gameObject.transform.localScale = currentScale;

            if (selectionTimeSoFar >= selectionTime)
            {
                PerformAction();
            }
        }
    }

    public void Select()
    {
        this.selected = true;
        this.gameObject.GetComponent<SpriteRenderer>().color = selectedColor;
        this.selectedAt = Time.time;
    }

    public void Deselect()
    {
        this.selected = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = notSelectedColor;
        this.gameObject.transform.localScale = initialScale;
    }

    public abstract void PerformAction();
}
