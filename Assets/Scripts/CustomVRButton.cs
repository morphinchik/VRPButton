using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomVRButton : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }
    [SerializeField]
    private Transform anchorTransform;
    [SerializeField]
    private float pressLength = 0.05f;
    public ButtonEvent downEvent;
    private bool pressed;
    private Vector3 startPos;
    private Vector3 startDistanceFromButtonToAnchor;
    void Start()
    {
        startPos = transform.position;
        startDistanceFromButtonToAnchor = anchorTransform.position - transform.position;
    }
    void Update()
    {
        Button();
    }
    private void Button()
    {
        Vector3 distanceFromButtonToAnchor = anchorTransform.position - transform.position;
        if (distanceFromButtonToAnchor.magnitude <= startDistanceFromButtonToAnchor.magnitude - pressLength)
        {
            transform.position = startPos + distanceFromButtonToAnchor.normalized * pressLength;
            if (!pressed)
            {
                pressed = true;
                downEvent?.Invoke();
                Debug.Log("button was pressed");
            }
        }
        if (distanceFromButtonToAnchor.magnitude > startDistanceFromButtonToAnchor.magnitude)
        {
            pressed = false;
            transform.position = startPos;
        }
    }
}
