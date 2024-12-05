using UnityEngine;

public class S_Terrain : MonoBehaviour
{
    public Transform NewTerrainPos;

    private void Awake()
    {
        Vector3 terrainSize = GetComponent<MeshCollider>().bounds.size;
        NewTerrainPos.position = transform.localPosition - new Vector3(terrainSize.x, terrainSize.y, 0);
    }
}