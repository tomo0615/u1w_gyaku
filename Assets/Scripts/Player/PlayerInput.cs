using UnityEngine;

public class PlayerInput
{
    private readonly KeyCode
        summonKey = KeyCode.Mouse0,
        allAttackKey = KeyCode.Mouse1,
        selectSlot1 = KeyCode.Q,
        selectSlot2 = KeyCode.W,
        selectSlot3 = KeyCode.E;
                                

    // MousePosition の方が好き
    public Vector3 MouseDirection => Input.mousePosition;

    public bool IsSummonSetting => Input.GetKey(summonKey);
    public bool IsSummon => Input.GetKeyUp(summonKey);

    public bool IsAllAttack => Input.GetKeyUp(allAttackKey);

    // else ない方が好き
    public int IsSelectSlot()
    {
        if (Input.GetKeyUp(selectSlot1))
        {
            return 0;
        }
        else if (Input.GetKeyUp(selectSlot2))
        {
            return 1;
        }
        else if (Input.GetKeyUp(selectSlot3))
        {
            return 2;
        }

        return -1;
    }
}
