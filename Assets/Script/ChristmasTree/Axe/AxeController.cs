using UnityEngine;

public class AxeController : MonoBehaviour
{
    private bool _canAnim;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _canAnim = true;
    }

    private void Update()
    {
        if (_canAnim)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _canAnim = false;
                _animator.SetBool("HitLeft", true);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _canAnim = false;
                _animator.SetBool("HitRight", true);
            }
        }
    }

    public void AnimFinished()
    {
        _canAnim = true;
    }
}