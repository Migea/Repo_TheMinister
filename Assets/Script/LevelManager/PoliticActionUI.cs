using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PoliticActionUI : MonoBehaviour, IPointerClickHandler
{
    public Animator animator;
    public GateHolderAnimationPlayer animPlayer;
    public GameObject MoneyDepartment;
    public GameObject DocumentDepartment;
    public GameObject PopulationDepartment;
    public void Show()
    {
        AudioManager.Play("��ҳ");
        animator.Play("Show");
    }
    public void Hide()
    {
        AudioManager.Play("��ҳ");
        animator.Play("Hide");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Hide();
        }
    }
    public IEnumerator AssassinSuccess()
    {
        Show();
        yield return new WaitForSeconds(0.4f);
        animPlayer.StartSequence();
    }
    public void StartAssassinSuccessAnimation(string pageName)
    {
        if (pageName == "����˾")
        {
            OpenDocumentDepartment();
        }
        else if (pageName == "��Ǯ˾")
        {
            OpenMoneyDepartment();
        }
        else if (pageName == "����˾")
        {
            OpenPopulationDepartment();
        }
        StartCoroutine(AssassinSuccess());
    }
    public void OpenMoneyDepartment()
    {
        MoneyDepartment.gameObject.SetActive(true);
        DocumentDepartment.gameObject.SetActive(false);
        PopulationDepartment.gameObject.SetActive(false);
        animPlayer.page = MoneyDepartment.GetComponent<GateholderAnimationPageRef>().targetRect;
    }
    public void OpenDocumentDepartment()
    {
        MoneyDepartment.gameObject.SetActive(false);
        DocumentDepartment.gameObject.SetActive(true);
        PopulationDepartment.gameObject.SetActive(false);
        animPlayer.page = DocumentDepartment.GetComponent<GateholderAnimationPageRef>().targetRect;
    }
    public void OpenPopulationDepartment()
    {
        MoneyDepartment.gameObject.SetActive(false);
        DocumentDepartment.gameObject.SetActive(false);
        PopulationDepartment.gameObject.SetActive(true);
        animPlayer.page = PopulationDepartment.GetComponent<GateholderAnimationPageRef>().targetRect;
    }
}
