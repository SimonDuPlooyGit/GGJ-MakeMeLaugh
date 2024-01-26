using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public RectTransform parent;
    public Camera cameraMain;
    public RectTransform aimer;
    public Canvas canvasMain;

    public RectTransform aimed;

    public Vector2 aimedPos;

    private void Start()
    {
        aimedPos = aimed.GetComponent<RectTransform>().anchoredPosition;
    }

    private void Update()
    {
        Vector2 AnchoredPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, Input.mousePosition, canvasMain.renderMode == RenderMode.ScreenSpaceOverlay ? null : cameraMain, out AnchoredPosition);
        aimer.anchoredPosition = AnchoredPosition;

        Debug.Log(AnchoredPosition);

        AnchoredPosition.x -= aimedPos.x;
        AnchoredPosition.y -= aimedPos.y;

        var angles = Mathf.Atan2(AnchoredPosition.y, AnchoredPosition.x) * Mathf.Rad2Deg;

        aimed.rotation = Quaternion.Euler(new Vector3(0, 0, angles));
    }
}
