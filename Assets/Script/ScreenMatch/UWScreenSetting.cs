using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UWScreenSetting : MonoBehaviour
{
    public RectTransform target;
    private float widthOrigin = 1920;
    private float heightOrigin = 1080;

    private float scaleOrigin = 1;

    private Vector2 anchorPositionOrigin = new Vector2(0f, 0f);

    public bool setWidthNHight = false;
    public float widthUW = 0f;
    public float hightUW = 0f;

    public bool setScale = false;
    public float scaleUW = 1;

    public bool setAnchorPosition = false;
    public Vector2 anchorPositionUW = new Vector2(0f, 0f);

    private const float UltrawideAspectRatioThreshold = 21f / 9f;
    private bool WideSetDone = false;

    private void Awake()
    {
        widthOrigin = target.rect.width;
        heightOrigin = target.rect.height;
        anchorPositionOrigin = target.anchoredPosition;
        scaleOrigin = target.localScale.x;
    }
    public void SetToUW()
    {
        if (setWidthNHight)
        {
            target.sizeDelta = new Vector2(widthUW, hightUW);
        }
        if (setScale)
        {
            target.localScale = new Vector3(scaleUW*scaleOrigin, scaleUW * scaleOrigin, 1);
        }
        if (setAnchorPosition)
        {
            target.anchoredPosition = anchorPositionUW;
        }
        WideSetDone = true;
    }
    public void SetToOrigin()
    {
        if (setWidthNHight)
        {
            target.sizeDelta = new Vector2(widthOrigin, heightOrigin);
        }
        if (setScale)
        {
            target.localScale = new Vector3(scaleOrigin, scaleOrigin, 1);
        }
        if (setAnchorPosition)
        {
            target.anchoredPosition = anchorPositionOrigin;
        }
        WideSetDone = false;
    }
    public void FixedUpdate()
    {
        bool isWide = IsWide();
        if (isWide && !WideSetDone)
        {
            SetToUW();
        }
        else if (!isWide && WideSetDone)
        {
            SetToOrigin();
        }
    }
    public bool IsWide()
    {
        float screenAspect = (float)Screen.width / Screen.height;

        if (screenAspect >= UltrawideAspectRatioThreshold)
        {
            return true;
        }
        return false;
    }
}
