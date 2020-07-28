using UnityEngine;

public class PlayerInput
{
    private readonly KeyCode
        summonKey = KeyCode.Mouse0,
        allAttackKey = KeyCode.Mouse1,
        selectSlot1 = KeyCode.Q,
        selectSlot2 = KeyCode.W,
        selectSlot3 = KeyCode.E;
                                

    public Vector3 MouseDirection => Input.mousePosition;

    public bool IsSummonSetting => Input.GetKey(summonKey);
    public bool IsSummon => Input.GetKeyUp(summonKey);

    public bool IsAllAttack => Input.GetKeyUp(allAttackKey);

    public UnitType GetSelectSlot()
    {
        if (Input.GetKeyUp(selectSlot1))
        {
            return UnitType.Normal;
        }
        else if (Input.GetKeyUp(selectSlot2))
        {
            return UnitType.Shield;
        }
        else if (Input.GetKeyUp(selectSlot3))
        {
            return UnitType.Shield;
        }

        return UnitType.Normal;
    }

    public bool IsSelectSlot()
    {
        return GetSelectSlot() > 0;
    }
}
