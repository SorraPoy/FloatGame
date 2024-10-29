using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RandomObjectWhenClick : MonoBehaviour
{
    public GameObject Island;
    public GameObject[] objects;
    public Transform[] positions;

    private Dictionary<GameObject, Transform> objectPositions;
    private Vector3[] initialPositions;

    private void Start()
    {
        objectPositions = new Dictionary<GameObject, Transform>();
        initialPositions = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            initialPositions[i] = objects[i].transform.position;
        }
    }

    public void RandomizeObjects()
    {


        List<Transform> availablePositions = new List<Transform>(positions);
        objectPositions.Clear();

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

            // Keep the Y position fixed
            Vector3 newPosition = new Vector3(randomPosition.position.x, obj.transform.position.y, randomPosition.position.z);

            obj.transform.position = newPosition;
            objectPositions.Add(obj, randomPosition);

            availablePositions.RemoveAt(randomIndex);
        }
    }

    private bool IsObjectInIsland(GameObject obj)
    {
        // Check if the object is a child of the Island game object
        return obj.transform.IsChildOf(Island.transform);
    }

}