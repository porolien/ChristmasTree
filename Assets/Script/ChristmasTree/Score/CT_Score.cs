using UnityEngine;

public class CT_Score : MonoBehaviour
{
    private float _score;

    private void Start()
    {
        _score = 0;
        ShowScore();
    }

    public void GainScore(float scoreGain)
    {
        _score += scoreGain;
        ShowScore();
    }

    private void ShowScore()
    {
        CT_GameManager.Instance.UI.ShowScore(_score);
    }
}
