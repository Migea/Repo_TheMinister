using SaveSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum FactionType
{
    �޵���,
    �,
    ��ǧ��,
    ʿ���ŷ�,
    �ڵ�,
    ����
}
public class PoliticFactionManager : MonoBehaviour
{
    public static PoliticFactionManager Instance;
    public SOPoliticFaction db = null;
    public List<PoliticFaction> factions = new List<PoliticFaction>();
    public void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    public void Reset()
    {
        factions.Clear();
    }
    public void Setup()
    {
        factions = db.politicFactions;
    }
    public void Load(GameSave save)
    {

    }

}
