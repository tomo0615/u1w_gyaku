using UnityEngine;

public class PlayerInput
{
    private KeyCode
        summonKey = KeyCode.Mouse0;

    public Vector3 MouseDirection => Input.mousePosition;

    public bool IsSummonSetting => Input.GetKey(summonKey);
    public bool IsSummon => Input.GetKeyUp(summonKey);
}
