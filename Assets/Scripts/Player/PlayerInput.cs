using UnityEngine;

public class PlayerInput : IPlayerInput
{
    private Vector3 touchStartPosition;
    private Vector3 touchEndPosition;


    public void Inputting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPosition = new Vector3(Input.mousePosition.x, 0);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPosition = new Vector3(Input.mousePosition.x, 0);

            GetSwipeOrTap();
        }
    }

    private void GetSwipeOrTap()
    {
        float directionX = touchEndPosition.x - touchStartPosition.x;
        float directionY = touchEndPosition.y - touchStartPosition.y;

        if (Mathf.Abs(directionX - directionY) != 0)
        {
            Debug.Log("Swipe");
        }
        else
        {
            //タッチを検出
            Debug.Log("Tap");
        }
    }

    public Vector3
}
