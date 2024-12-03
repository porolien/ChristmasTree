using UnityEngine;

public class CT_Object : MonoBehaviour
{
    [HideInInspector]
    public bool ChangeScore;

    [HideInInspector]
    public float NumberScore;

    [HideInInspector]
    public bool ChangeTime;

    [HideInInspector]
    public float NumberTime;

    [HideInInspector]
    public bool LoseTheGame;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private CT_ObjectScriptable _objectSerialyse;

    private void Awake()
    {
        _objectSerialyse.SetObject(this);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Axe")
        {
            Interact();
        }

        if (other.tag == "DeadBox")
        {
            Destroy(gameObject);
        }
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

        Destroy(gameObject);
    }
}