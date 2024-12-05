using System.Collections.Generic;
using UnityEngine;

public class S_TerrainManager : MonoBehaviour
{
    private List<S_Terrain> terrainList = new List<S_Terrain>();

    private void InvokeNewTerrain()
    {
        // invoke à -> terrainList[terrainList.Count-1]._newTerrainPos
    }
}