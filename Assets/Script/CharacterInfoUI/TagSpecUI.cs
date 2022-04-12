using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagSpecUI : MonoBehaviour
{
    public Tag originTag;
    public Image tagIcon;
    public Text Info;

    public void SetUp(Tag tag, bool origin = true)
    {
        if (origin)
        {
            originTag = tag;
        }
        SetTagIcon(tag,origin);
        SetTagInfo(tag,origin);
    }

    public virtual void SetTagIcon(Tag tag, bool origin = true)
    {
        tagIcon.sprite = FindTagSprite(tag);
    }

    public static Sprite FindTagSprite(Tag tag)
    {
        string FolderPathOfTags = $"Art/Tags/{tag.ToString()}";
        return Resources.Load<Sprite>(FolderPathOfTags);
    }
    
    public virtual void SetTagInfo(Tag tag, bool origin = true)
    {
        string output = "";
        output +=
            "��" + PlusOrMinus(Player.TagInfDict[tag][0]) + " "
            + "��" + PlusOrMinus(Player.TagInfDict[tag][1]) + " "
            + "ı" + PlusOrMinus(Player.TagInfDict[tag][2]) + " "
            + "��" + PlusOrMinus(Player.TagInfDict[tag][3]) + " "
            + "��" + PlusOrMinus(Player.TagInfDict[tag][4]) + " "
            + "��" + PlusOrMinus(Player.TagInfDict[tag][5]);
        Info.text = output;
    }
    public static string PlusOrMinus(int input)
    {
        string output = "";
        string outputSign = "+";
        if (input < 0) outputSign = "-";
        for (int i =0; i < Mathf.Abs(input); i++)
        {
            output += outputSign;
        }
        return output;
    }
}
