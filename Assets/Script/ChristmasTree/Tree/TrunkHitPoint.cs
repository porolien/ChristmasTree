using UnityEngine;

public class TrunkHitPoint : MonoBehaviour
{
    private TreeSystem _tree;

    public void Init(TreeSystem tree)
    {
        _tree = tree;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Axe")
        {
            CT_GameManager.Instance.Time.GainTime(1);
            CT_GameManager.Instance.Score.GainScore(1);
            _tree.RemoveBottomTrunk();
        }
    }
}