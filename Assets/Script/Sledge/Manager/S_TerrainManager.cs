using System.Collections.Generic;
using UnityEngine;

public class S_TerrainManager : MonoBehaviour
{
    [SerializeField]
    private int _numberOfTerrain;

    [SerializeField]
    private List<S_Terrain> _allTerrainsAvailable = new List<S_Terrain>();

    [SerializeField]
    private Transform _initPos;

    private List<S_Terrain> _terrainList = new List<S_Terrain>();

    private void Start()
    {
        for (int i = 0; i < _numberOfTerrain; i++)
        {
            InvokeNewTerrain();
        }
    }

    private void InvokeNewTerrain()
    {
        int terrainRandom = Random.Range(0, _allTerrainsAvailable.Count);
        S_Terrain terrain = _allTerrainsAvailable[terrainRandom];
        _allTerrainsAvailable.Remove(_allTerrainsAvailable[terrainRandom]);
        if (_terrainList.Count != 0)
        {
            terrain.transform.position = _terrainList[_terrainList.Count - 1].NewTerrainPos.position;
        }
        else
        {
            terrain.transform.position = _initPos.position;
        }

        _terrainList.Add(terrain);
    }
}