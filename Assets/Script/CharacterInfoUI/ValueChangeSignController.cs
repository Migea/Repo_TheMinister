using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChangeSignController : MonoBehaviour
{
    public Transform Wisdom;
    public Transform Writing;
    public Transform Strategy;
    public Transform Strength;
    public Transform Sneak;
    public Transform Defense;
    public void Start()
    {
        Reset();
    }
    public void Reset()
    {
        foreach (Transform child in Wisdom)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in Writing)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in Strategy)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in Strength)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in Sneak)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in Defense)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void ValueChange(CharacterValueType valueType, bool up)
    {
        Transform target = Wisdom;
        switch (valueType)
        {
            case (CharacterValueType.��):
                target = Wisdom;
                break;
            case (CharacterValueType.��):
                target = Writing;
                break;
            case (CharacterValueType.ı):
                target = Strategy;
                break;
            case (CharacterValueType.��):
                target = Strength;
                break;
            case (CharacterValueType.��):
                target = Sneak;
                break;
            case (CharacterValueType.��):
                target = Defense;
                break;
        }
        if (up)
        {
            target.Find("��").gameObject.SetActive(true);
        }
        else
        {
            target.Find("��").gameObject.SetActive(true);
        }
    }
}
