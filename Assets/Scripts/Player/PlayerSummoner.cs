using UnityEngine;

public class PlayerSummoner : MonoBehaviour
{
    [SerializeField]
    private BaseUnit unit = null;

    public void SummonUnit(Vector3 summonPosition)
    {
        Instantiate(unit, summonPosition, Quaternion.identity);
    }

}
