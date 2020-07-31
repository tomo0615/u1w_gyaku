using Unit;
using UnityEngine;

public class PlayerInput
{
    private const
        KeyCode SummonKey = KeyCode.Mouse0, 
        AllAttackKey = KeyCode.Mouse1,
        SelectSlot1 = KeyCode.Q,
        SelectSlot2 = KeyCode.W,
        SelectSlot3 = KeyCode.E;


    public Vector3 MouseDirection => Input.mousePosition;

    public bool IsSummonSetting => Input.GetKey(SummonKey);
    public bool IsSummon => Input.GetKeyUp(SummonKey);

    public bool IsAllAttack => Input.GetKeyUp(AllAttackKey);
    
    public int GetSelectSlot()
    {
        if (Input.GetKeyUp(SelectSlot1))
        {
            return 0;
        }

        if (Input.GetKeyUp(SelectSlot2))
        {
            return 1;
        }

        if (Input.GetKeyUp(SelectSlot3))
        {
            return 2;
        }

        return -1;
    }

    public bool IsSelectSlot()
    {
        return GetSelectSlot() >= 0;
    }
}
