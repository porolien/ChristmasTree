using UnityEngine;
using UnityEngine.InputSystem;

public class SledgeControl : MonoBehaviour
{
    private SledgeVelocity _sledgeVelocity;

    private void Awake()
    {
        _sledgeVelocity = GetComponent<SledgeVelocity>();
    }

    private void OnMovement(InputValue _moveValue)
    {
        _sledgeVelocity.MoveDirection(_moveValue.Get<Vector3>().x);
    }
}
