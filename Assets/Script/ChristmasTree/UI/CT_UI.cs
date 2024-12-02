using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CT_UI : MonoBehaviour
{
    [SerializeField]
    private Image _actualTimeBar;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    private void Start()
    {
        CT_GameManager.Instance.UI = this;
    }

    public void ShowTime(float pourcent)
    {
        _actualTimeBar.fillAmount = pourcent;
    }

    public void ShowScore(float score)
    {
        _scoreText.text = "" + score;
    }
}