using UnityEngine;

public class CT_Time : MonoBehaviour
{
    [SerializeField]
    private float _maxTime;

    private float _actualTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _actualTime = _maxTime;
        CT_GameManager.Instance.Time = this;   
    }

    private void Update()
    {
        _actualTime -= Time.deltaTime;
        ShowTime();
        if (_actualTime <= 0)
        {
            NoMoreTime();
        }
    }

    public void GainTime(float timeGain)
    {
        _actualTime += timeGain;
        ShowTime();
        if ( _actualTime > _maxTime )
        {
            _actualTime = _maxTime;
        }
    }

    public void LoseTime(float timeGain)
    {
        _actualTime -= timeGain;
        ShowTime();
        if (_actualTime <= 0)
        {
            NoMoreTime();
        }
    }

    public void NoMoreTime()
    {
        Debug.Log("Lose");
    }

    private void ShowTime()
    {
        CT_GameManager.Instance.UI.ShowTime(_actualTime / _maxTime);
    }
}
