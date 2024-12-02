using System.Collections.Generic;
using UnityEngine;

public class CT_ObjectManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> Objects = new List<GameObject>();

    [SerializeField]
    private List<Transform> ObjectsSpawnsPos = new List<Transform>();

    private void Start()
    {
        InvokeRepeating("SpawnObjects", 5, Random.Range(3, 6));
    }

    private void SpawnObjects()
    {
        Debug.Log("Spawn");
        Instantiate(Objects[Random.Range(0,Objects.Count)], ObjectsSpawnsPos[Random.Range(0, ObjectsSpawnsPos.Count)]);
    }
}