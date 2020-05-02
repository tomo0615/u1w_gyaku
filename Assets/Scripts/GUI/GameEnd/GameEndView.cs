using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndView : MonoBehaviour
{
    public void ActiveGameEndView(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
