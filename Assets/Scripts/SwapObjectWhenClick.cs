using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObjectWhenClick : MonoBehaviour
{
    public ParticleSystem objectParticleSystem;

    private static Transform firstObject;
    private static Transform secondObject;
    private static bool isFirstObjectClicked = false;

    public GameObject targetObject;
    public AnimationClip FloatUpAnimation;
    public AnimationClip FloatDownAnimation;
    public AnimationClip SwapOBJ1Animation;
    public AnimationClip SwapOBJ2Animation;
    public AnimationClip SwapAfterAnimation;
    private static GameObject target1;
    private static GameObject target2;

    private void OnMouseDown()
    {
        if (!isFirstObjectClicked)
        {
            // Mark the first object
            firstObject = transform;
            isFirstObjectClicked = true;

            target1 = targetObject;

            // Play the target animation
            PlayFloatUpAnimation();
        }
        else
        {
            // Check if the first target object is clicked again
            if (firstObject == transform && isFirstObjectClicked)
            {
                // Play the other animation
                PlayFloatDownAnimation();
                isFirstObjectClicked = false;
            }
            else
            {
                // Mark the second object
                secondObject = transform;

                target2 = targetObject;


                // Play the target animation
                PlayFloatUpAnimation();

                // Invoke the swap function after a delay
                Invoke("PerformSwap", 0.5f);
                PlaySwapAnimation();
            }
        }
    }

    private void PerformSwap()
    {
        // Swap positions of the first and second objects
        Vector3 tempPosition = firstObject.position;
        firstObject.position = secondObject.position;
        secondObject.position = tempPosition;

        // Reset the flags
        isFirstObjectClicked = false;

        // Get a reference to the FloatlandGame script on the game object
        FloatlandGame floatlandGame = FindObjectOfType<FloatlandGame>();

        // Call the ObjectSwapped function in the FloatlandGame script
        floatlandGame.ObjectSwapped(firstObject.gameObject);
        floatlandGame.ObjectSwapped(secondObject.gameObject);
    }

    public void SetParticleSystemActive(bool active)
    {
        if (objectParticleSystem != null)
        {
            if (active)
            {
                objectParticleSystem.Play();
            }
            else
            {
                objectParticleSystem.Stop();
            }
        }
    }

    public void PlayFloatUpAnimation()
    {
        if (targetObject != null && FloatUpAnimation != null)
        {
            Animation targetAnimation = targetObject.GetComponent<Animation>();
            if (targetAnimation != null)
            {
                targetAnimation.Stop();
                targetAnimation.clip = FloatUpAnimation;
                targetAnimation.Play();
            }
        }
    }

    public void PlayFloatDownAnimation()
    {
        if (targetObject != null && FloatDownAnimation != null)
        {
            Animation targetAnimation = targetObject.GetComponent<Animation>();
            if (targetAnimation != null)
            {
                targetAnimation.Stop();
                targetAnimation.clip = FloatDownAnimation;
                targetAnimation.Play();
            }
        }
    }

    public void PlaySwapAnimation()
    {
        if (target1 != null && SwapOBJ1Animation != null && SwapOBJ1Animation != null)
        {
            Animation targetAnimation1 = target1.GetComponent<Animation>();
            if (targetAnimation1 != null)
            {
                targetAnimation1.clip = SwapOBJ1Animation;
                targetAnimation1.PlayQueued(SwapOBJ1Animation.name, QueueMode.CompleteOthers);
                targetAnimation1.clip = SwapAfterAnimation;
                targetAnimation1.PlayQueued(SwapAfterAnimation.name, QueueMode.CompleteOthers);
            }
        }
        if (target2 != null && SwapOBJ2Animation != null && SwapOBJ2Animation != null)
        {
            Animation targetAnimation2 = target2.GetComponent<Animation>();
            if (targetAnimation2 != null)
            {
                targetAnimation2.Stop();
                targetAnimation2.clip = SwapOBJ2Animation;
                targetAnimation2.PlayQueued(SwapOBJ2Animation.name, QueueMode.CompleteOthers);
                targetAnimation2.clip = SwapAfterAnimation;
                targetAnimation2.PlayQueued(SwapAfterAnimation.name, QueueMode.CompleteOthers);
            }
        }
    }
}