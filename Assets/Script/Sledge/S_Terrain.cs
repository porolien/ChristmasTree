using System;
using UnityEngine;

public class S_Terrain : MonoBehaviour
{
    public Transform NewTerrainPos;
    public event Action SledgePassNewTerrain;

    private void Awake()
    {
        Vector3 terrainSize = GetComponent<Collider>().bounds.size;
        NewTerrainPos.position = transform.localPosition - new Vector3(terrainSize.x, terrainSize.y, 0);
    }

    public void ClearEvents()
    {
        SledgePassNewTerrain = null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SledgePassNewTerrain.Invoke();
        }
    }
}