using DG.Tweening;
using UnityEngine;

public class CameraController
{
    // readonly にしたい
    private Camera mainCamera;

    private bool isShaking = false;

    public CameraController(Camera _mainCamera)
    {
        mainCamera = _mainCamera;
    }

    //カメラの揺れ
    public void ShakeCamera(float time)
    {
        if (isShaking) return;
        isShaking = true;

        mainCamera.DOShakePosition(time)
            .OnComplete(() =>
            {
                isShaking = false;
            });
    }
}
