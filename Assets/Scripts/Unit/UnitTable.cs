using UnityEngine;

[CreateAssetMenu(menuName = "UnitTable", fileName = "UnitTable")]
public class UnitTable : ScriptableObject
{
    public NormalUnit normalUnit;

    public ShieldUnit shieldUnit;

    public CannonUnit cannonUnit;
}
