using UnityEngine;

public class CT_Object : MonoBehaviour
{
    //[HideInInspector]
    public bool ChangeScore;

    //[HideInInspector]
    public float NumberScore;

    [HideInInspector]
    public bool ChangeTime;

    [HideInInspector]
    public float NumberTime;

    [HideInInspector]
    public bool LoseTheGame;

    [SerializeField]
    private CT_ObjectScriptable _objectSerialyse;

    private void Awake()
    {
        _objectSerialyse.SetObject(this);
    }

    private void Start()
    {
        Invoke("Interact", 2);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 1, 1));
    }

    public void Interact()
    {
        if (ChangeScore)
        {
            CT_GameManager.Instance.Score.GainScore(NumberScore);
        }

        if (ChangeTime)
        {
            CT_GameManager.Instance.Time.GainTime(NumberTime);
        }

        if (LoseTheGame)
        {
            CT_GameManager.Instance.Time.NoMoreTime();
        }
    }
}