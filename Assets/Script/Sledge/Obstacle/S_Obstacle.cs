using UnityEngine;

public class S_Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //faire des dégâts
        }
    }
}
