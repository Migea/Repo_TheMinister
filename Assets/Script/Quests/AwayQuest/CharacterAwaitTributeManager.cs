using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAwaitTributeManager : MonoBehaviour, IDiceRollEvent
{
    public static CharacterAwaitTributeManager Instance;
    public List<CharacterAwaitTribute> UnfinishedTributes = new List<CharacterAwaitTribute>();
    public CharacterAwaitTribute awaitTributePrefab;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            awaitTributePrefab.gameObject.SetActive(false);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        Dice.Instance.RegisterObserver(this);
    }
    public CharacterAwaitTribute AddTribute(Character character, int WaitTime, UnityEvent @event, bool auto)
    {
        var tribute = Instantiate(awaitTributePrefab, transform);
        tribute.gameObject.SetActive(true);
        tribute.character = character;
        tribute.WaitTime = WaitTime;
        tribute.@event.AddListener(@event.Invoke);
        UnfinishedTributes.Add(tribute);
        GeneralTrackingViewManager.Instance.PushTracker(character, character.CharacterName, "������Ϣϵͳ", WaitTime, auto);
        return tribute;
    }
    public void OnNotify(object value, NotificationType notificationType)
    {
        List<CharacterAwaitTribute> toDestroy = new List<CharacterAwaitTribute>();
        for (int i = 0; i < UnfinishedTributes.Count; i++)
        {
            if (UnfinishedTributes[i] != null)
                UnfinishedTributes[i].TimePlus();
            if (UnfinishedTributes[i].destroyNext)
            {
                toDestroy.Add(UnfinishedTributes[i]);
            }
        }
        if (toDestroy.Count > 0) { DestroyAfterSec(toDestroy); }
    }
    public void DestroyAfterSec(List<CharacterAwaitTribute> toDestroy)
    {
        if (toDestroy.Where(x => x != null).Count() >= 0)
        {
            foreach (var tribute in toDestroy)
            {
                if (tribute != null)
                {
                    Destroy(tribute.gameObject);
                }
            }
            UnfinishedTributes.RemoveAll(x => x == null);
        }
    }
    public void Reset()
    {
        foreach (var tribute in UnfinishedTributes)
        {
            if (tribute != null)
                Destroy(tribute.gameObject);
        }
        UnfinishedTributes = new List<CharacterAwaitTribute>();
    }
}
