using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    private static S_GameManager _instance = null;
    public static S_GameManager Instance => _instance;

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
