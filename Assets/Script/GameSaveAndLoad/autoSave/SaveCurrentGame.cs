using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveCurrentGame : MonoBehaviour
{
    public bool SaveOnEnable = false;
    public string SaveName = "�Զ��浵";
    private void OnEnable()
    {
        if (SaveOnEnable)
        {
            Save();
        }
    }
    public void Save()
    {
        if (GameEventManager.Instance.SaveReady == false)
        {
            return;
        }
        else
        {
            var alert = Instantiate<Text>(Resources.Load<Text>("Hiring/Message"), MainCanvas.FindMainCanvas());
            alert.text = "�����ѱ���";
            FindObjectOfType<SaveAndLoadManager>().SaveGame(SaveName);
        }
    }
}
