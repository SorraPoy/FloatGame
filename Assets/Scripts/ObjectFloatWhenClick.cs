using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloatWhenClick : MonoBehaviour
{
    private bool isFloating = false;
    private Vector3 originalPosition;
    private Vector3 firstPosition;
    private Vector3 targetPosition;
    public float floatHeight = 0.5f;
    public float floatSpeed = 1f;

    private void Start()
    {
        originalPosition = transform.position;
        firstPosition = transform.position;
        targetPosition = originalPosition;
    }

    private void FixedUpdate()
    {
        if (isFloating || !isFloating)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, floatSpeed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        if (!isFloating)
        {
            targetPosition = originalPosition + Vector3.up * floatHeight;
            isFloating = true;
            Debug.Log("isFloating: " + isFloating);
        }
        else
        {
            targetPosition = firstPosition;
            isFloating = false;
            Debug.Log("isFloating: " + isFloating);
        }

    }
}