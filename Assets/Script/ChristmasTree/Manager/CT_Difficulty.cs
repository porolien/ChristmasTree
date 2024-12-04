using System.Collections.Generic;
using UnityEngine;

public class CT_Difficulty : MonoBehaviour
{
    private int _actualDifficulty;

    public int ActualDifficulty
    {
        get { return _actualDifficulty; }
        set 
        {
            _actualDifficulty = value;
            ChangeDifficulty();
        }
    }

    [SerializeField]
    private List<float> _timeChanges = new List<float>();

    [SerializeField]
    private float _difficultyPercent;

    public void ChangeDifficulty()
    {
        Time.timeScale = _timeChanges[ActualDifficulty];
    }

    public void InfiniteDifficulty(float scoreMaxNeeded)
    {
        Time.timeScale = _timeChanges[ActualDifficulty] + (CT_GameManager.Instance.Score.Score - scoreMaxNeeded) / _difficultyPercent;
    }
}
