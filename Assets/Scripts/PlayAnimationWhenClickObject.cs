using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationWhenClickObject : MonoBehaviour
{
    public AnimationClip clickAnimation;
    public AnimationClip resetAnimation;

    public GameObject targetObject;

    private Animation targetAnimation;
    private bool isClicked = false;

    private void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            enabled = false;
            return;
        }

        targetAnimation = targetObject.GetComponent<Animation>();

        if (targetAnimation == null)
        {
            targetAnimation = targetObject.AddComponent<Animation>();
        }

        targetAnimation.AddClip(clickAnimation, clickAnimation.name);
        targetAnimation.AddClip(resetAnimation, resetAnimation.name);
    }

    private void OnMouseDown()
    {
        if (isClicked)
        {
            targetAnimation.Play(resetAnimation.name);
        }
        else
        {
            targetAnimation.Play(clickAnimation.name);
        }

        isClicked = !isClicked;
    }
}