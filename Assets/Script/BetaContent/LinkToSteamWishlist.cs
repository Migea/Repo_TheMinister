using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.EventSystems;

public class LinkToSteamWishlist : MonoBehaviour,IPointerClickHandler
{
    public string url = "https://store.steampowered.com/app/1234567";
    /// <summary>
    /// ����Ը����, url������Ϸ���̵�ҳ��ַ
    /// </summary>
    public void AddToSteamWish(string url)
    {
#if DISABLESTEAMWORKS || UNITY_EDITOR
        Application.OpenURL(url);
#else
        // ֻ������Ը����ҳ�棬���������Ը����
        SteamFriends.ActivateGameOverlayToWebPage(url);
#endif
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AddToSteamWish(url);
    }
}
