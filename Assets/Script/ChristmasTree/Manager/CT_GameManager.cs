using UnityEngine;

public class CT_GameManager : MonoBehaviour
{
    private static CT_GameManager _instance = null;
    public static CT_GameManager Instance => _instance;

    public CT_Score Score;
    public CT_Time Time;
    public CT_UI UI;
    public CT_Difficulty Difficulty;

    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            _instance.Awake();
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
