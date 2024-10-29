using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatlandGame : MonoBehaviour
{
    //public static FloatlandGame instance;

    public GameObject[] objects;
    public Transform[] positions;
    private Vector3[] initialPositions;
    public GameObject VictoryButton;
    public GameObject Wall;
    public GameObject WallButton;

    private Dictionary<GameObject, Transform> objectPositions;

    public GameObject Island;


    //private void Awake()
    //{

    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void CheckObjectPositions()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].transform.position == initialPositions[i])
            {
                objects[i].GetComponent<SwapObjectWhenClick>().SetParticleSystemActive(true);
            }
            else
            {
                objects[i].GetComponent<SwapObjectWhenClick>().SetParticleSystemActive(false);
            }
        }
    }

    private void Start()
    {
        objectPositions = new Dictionary<GameObject, Transform>();
        List<Transform> availablePositions = new List<Transform>(positions);
        initialPositions = new Vector3[objects.Length];

        for (int i = 0; i < objects.Length; i++)
        {
            initialPositions[i] = objects[i].transform.position;
        }

        foreach (GameObject obj in objects)
        {
            if (!IsObjectInIsland(obj))
                continue;

            if (availablePositions.Count == 0)
            {
                Debug.LogError("Not enough available positions!");
                return;
            }

            int randomIndex = Random.Range(0, availablePositions.Count);
            Transform randomPosition = availablePositions[randomIndex];

            obj.transform.position = randomPosition.position;
            objectPositions.Add(obj, randomPosition);

            availablePositions.RemoveAt(randomIndex);
        }
        CheckObjectPositions();
    }

    public bool CheckCompletion()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].transform.position != initialPositions[i])
            {
                return false; // If any object's position doesn't match its original position, the game is not completed
            }
        }
        return true; // All objects are in their original positions, so the game is completed
    }


    public void ObjectSwapped(GameObject swappedObject)
    {
        if (objectPositions.ContainsKey(swappedObject))
        {
            int index = System.Array.IndexOf(objects, swappedObject);

            if (objects[index].transform.position != initialPositions[index])
            {
                // Object is not in the correct position
                swappedObject.GetComponent<SwapObjectWhenClick>().SetParticleSystemActive(false);
            }
            else
            {
                // Object is in the correct position
                swappedObject.GetComponent<SwapObjectWhenClick>().SetParticleSystemActive(true);
            }

            if (CheckCompletion())
            {
                Debug.Log("Congratulations! You completed the game!");
                VictoryButton.SetActive(true);
                Wall.SetActive(true);
                WallButton.SetActive(true);
                // Perform any additional actions for game completion
            }
        }
    }

    private bool IsObjectInIsland(GameObject obj)
    {
        // Check if the object is a child of the Island game object
        return obj.transform.IsChildOf(Island.transform);
    }
}
