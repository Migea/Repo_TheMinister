using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.EventSystems;

public class LinkToSteamWishlist : MonoBehaviour, IPointerClickHandler
{
    public string url = "https://store.steampowered.com/app/1234567";
    /// <summary>
    /// ����Ը����, url������Ϸ���̵�ҳ��ַ
    /// </summary>
    public bool Large = false;
    public Animator animator;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Large == false)
        {
            animator.Play("Big");
            Large = true;
        }
        else
        {
            animator.Play("Small");
            Large = false;
        }
    }
    private void OnEnable()
    {
        animator.Play("Big");
        Large = true;
    }
    public void AddToSteamWish(string url)
    {
#if DISABLESTEAMWORKS || UNITY_EDITOR
        Application.OpenURL(url);
#else
        // ֻ������Ը����ҳ�棬���������Ը����
        SteamFriends.ActivateGameOverlayToWebPage(url);
#endif
    }

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    AddToSteamWish(url);
    //}
}
