using Unit;
using UnityEngine;

[CreateAssetMenu(menuName = "UnitTable", fileName = "UnitTable")]
public class UnitTable : ScriptableObject
{
    // getter で取得したい
    public NormalUnit normalUnit;

    public ShieldUnit shieldUnit;

    public CannonUnit cannonUnit;
}
