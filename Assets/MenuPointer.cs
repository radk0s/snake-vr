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
    private const float selectionTime = 2.5f;
    private Color selectedColor = Color.yellow;
    private Color notSelectedColor = Color.white;

    void Update()
    {
        //rotate
        Vector3 rotation = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        gameObject.transform.eulerAngles = rotation;
        


        if(selected && Time.time - selectedAt > selectionTime)
        {
            PerformAction();
        }
    }

    public void Select()
    {
        this.selected = true;
        this.gameObject.GetComponent<Renderer>().material.color = selectedColor;
        this.selectedAt = Time.time;
    }

    public void Deselect()
    {
        this.selected = false;
        this.gameObject.GetComponent<Renderer>().material.color = notSelectedColor;
    }

    public abstract void PerformAction();
}
