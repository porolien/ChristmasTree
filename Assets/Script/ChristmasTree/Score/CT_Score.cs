using System.Collections.Generic;
using UnityEngine;

public class CT_Score : MonoBehaviour
{
    [SerializeField]
    private List<float> _scoreNeededToChangeDifficulty = new List<float>();

    private float _score;

    public float Score
    {
        get {  return _score;}
    }

    private void Start()
    {
        _score = 0;
        ShowScore();
        SetDifficulty();
    }

    public void GainScore(float scoreGain)
    {
        _score += scoreGain;
        ShowScore();
        SetDifficulty();
    }

    private void ShowScore()
    {
        CT_GameManager.Instance.UI.ShowScore(_score);
    }

    private void SetDifficulty()
    {
        if (CT_GameManager.Instance.Difficulty.ActualDifficulty == _scoreNeededToChangeDifficulty.Count - 1)
        {
            CT_GameManager.Instance.Difficulty.InfiniteDifficulty(_scoreNeededToChangeDifficulty[_scoreNeededToChangeDifficulty.Count-1]);
        }
        else
        {
            if (_score >= _scoreNeededToChangeDifficulty[CT_GameManager.Instance.Difficulty.ActualDifficulty + 1])
            {
                CT_GameManager.Instance.Difficulty.ActualDifficulty++;
            }
        }
    }
}
