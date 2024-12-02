using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class TreeSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _trunksPrefab;

    [SerializeField]
    private Transform _sapwnTrunkPoint;

    [SerializeField]
    private float _trunkHeight;

    [SerializeField]
    private List<GameObject> _trunksList = new List<GameObject>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            // Initialiser la liste de troncs
            _trunksList.Add(child.gameObject);
        }
    }

    public void RemoveBottomTrunk()
    {
        if (_trunksList.Count > 0)
        {
            // Détruire le tronc du bas
            GameObject bottomTrunk = _trunksList[0];
            _trunksList.RemoveAt(0);
            Destroy(bottomTrunk);

            // Faire descendre les troncs restant
            for (int i = 0; i < _trunksList.Count; i++)
            {
                Vector3 newPosition = _trunksList[i].transform.position;
                newPosition.y -= _trunkHeight;
                _trunksList [i].transform.position = newPosition;
            }

            // Ajoute un tronc en haut
            AddTrunk();
        }
    }

    private void AddTrunk()
    {
        // Calcul la position pour le nouveau tronc
        Vector3 newPosition = _sapwnTrunkPoint.position;
        if (_trunksList.Count > 0)
        {
            newPosition.y = _trunksList[_trunksList.Count - 1].transform.position.y + _trunkHeight;
        }

        // Instancie le tronc
        GameObject newTrunk = Instantiate(_trunksPrefab, newPosition, Quaternion.identity);
        _trunksList.Add(newTrunk);
    }
}
