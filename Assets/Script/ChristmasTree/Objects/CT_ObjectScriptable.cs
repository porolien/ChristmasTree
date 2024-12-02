using UnityEngine;

[CreateAssetMenu(fileName = "CT_ObjectScriptable", menuName = "Scriptable Objects/CT_Bonus_Malus")]
public class CT_ObjectScriptable : ScriptableObject
{
    [SerializeField]
    private bool _changeScore;

    [SerializeField]
    private float _numberScore;

    [SerializeField]
    private bool _changeTime;

    [SerializeField]
    private float _numberTime;

    [SerializeField]
    private bool _loseTheGame;

    public void SetObject(CT_Object obj)
    {
        obj.ChangeScore = _changeScore;
        obj.ChangeTime = _changeTime;
        obj.NumberScore = _numberScore;
        obj.NumberTime = _numberTime;
        obj.LoseTheGame = _loseTheGame;
    }
}
