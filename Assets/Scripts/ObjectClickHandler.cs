using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    private bool isFloating = false;
    private Vector3 notFloatObjectPosition;
    private Vector3 originObjectPosition;
    private Vector3 targetPosition;
    public float floatHeight = 0.5f;
    public float floatSpeed = 1f;
    private static Transform firstObject;
    private static Transform secondObject;
    private static bool isFirstObjectClicked = false;

    private void Start()
    {
        //Save the original position of objects
        notFloatObjectPosition = transform.position;
        originObjectPosition = transform.position;
        targetPosition = notFloatObjectPosition;
    }

    private void FixedUpdate()
    {
        //Float up,down function
        if (isFloating || !isFloating)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, floatSpeed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        if (!isFirstObjectClicked)
        {
            //When player click at the object. The object will float up
            targetPosition = notFloatObjectPosition + Vector3.up * floatHeight;
            isFloating = true;
            Debug.Log("isFloating: " + isFloating);

            // Mark the first object
            firstObject = transform;
            isFirstObjectClicked = true;
        }
        else
        {
            // If player click the object again, it will float down to original position
            targetPosition = originObjectPosition;
            isFloating = false;
            Debug.Log("isFloating: " + isFloating);


            // Mark the second object
            secondObject = transform;

            // Swap positions of the first and second objects
            Vector3 tempPosition = firstObject.position;
            firstObject.position = secondObject.position;
            secondObject.position = tempPosition;

            //Put down the floating object


            // Reset the isFirstObjectClicked flag
            isFirstObjectClicked = false;
        }

    }
}