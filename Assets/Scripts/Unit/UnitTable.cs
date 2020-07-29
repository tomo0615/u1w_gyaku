using Unit;
using UnityEngine;

[CreateAssetMenu(menuName = "UnitTable", fileName = "UnitTable")]
public class UnitTable : ScriptableObject
{
    [SerializeField] private NormalUnit normalUnit;
    public NormalUnit NormalUnit => normalUnit;

    [SerializeField] private ShieldUnit shieldUnit;
    
    public ShieldUnit ShieldUnit => shieldUnit;

    [SerializeField] private CannonUnit cannonUnit;
    
    public CannonUnit CannonUnit => cannonUnit;
}
