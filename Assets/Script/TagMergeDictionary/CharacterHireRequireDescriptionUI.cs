using Language.Lua;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class CharacterHireRequireDescriptionUI : MonoBehaviour
{
    public Text requestText;
    public Vector2 offset = new Vector2(85, -35);  // Offset from the mouse position
    private RectTransform imageRectTransform;
    private RectTransform canvasRectTransform;
    public Color NColor = Color.white;
    public Color RColor = Color.white;
    public Color SRColor = Color.white;
    public Color SSRColor = Color.white;
    public Color URColor = Color.white;
    private static Dictionary<CharacterArtCode, Dictionary<Rarerity, Dictionary<ItemName, int>>> CharacterArtCodeToRarityItemRequestDict => CharacterHiringEvent.CharacterArtCodeToRarityItemRequestDict;
    private void Awake()
    {
        imageRectTransform = GetComponent<RectTransform>();
        canvasRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    private void Update()
    {
        SetPositionNextToMouse();
    }
    private void Setup(Character character)
    {
        var requestItems = CharacterArtCodeToRarityItemRequestDict[character.characterArtCode][character.rarerity];
        string text = string.Empty;
        foreach (var item in requestItems)
        {
            if (text != string.Empty) text += "\n";

            Color rareColor = NColor;
            var Rarity = Player.AllTagRareDict[Use(item.Key)] != Rarerity.B ? Player.AllTagRareDict[Use(item.Key)] : Rarerity.N;
            if (Rarity == Rarerity.R) rareColor = RColor;
            else if (Rarity == Rarerity.SR) rareColor = SRColor;
            else if (Rarity == Rarerity.SSR) rareColor = SSRColor;
            else if (Rarity == Rarerity.UR) rareColor = URColor;
            string valueColor = HaveEnough(item.Value <= HaveAmount(item.Key));
            LocalizedString itemString = new LocalizedString
            {
                TableReference = "Item",
                TableEntryReference = $"{item.Key.ToString()}"
            };
            string line = $"<color=#{ColorUtility.ToHtmlStringRGBA(rareColor)}>{itemString.GetLocalizedString()}</color> * <color={valueColor}>{HaveAmount(item.Key)}</color>/{item.Value}";
            text += line;
        }
        requestText.text = text;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    public int HaveAmount(ItemName itemName)
    {
        var PlayerItemDic = GameObject.FindGameObjectWithTag("PlayerItemInventory").GetComponent<ItemInventory>().ItemDict;

        int HaveAmount = 0;
        if (PlayerItemDic.ContainsKey(itemName))
        {
            HaveAmount = PlayerItemDic[itemName];
        }
        return HaveAmount;
    }
    public string HaveEnough(bool success)
    {
        string color = success ? "#60FF45" : "#FF0000";
        return color;
    }
    public static void Show(Character character)
    {
        var ui = FindObjectOfType<CharacterHireRequireDescriptionUI>(true);
        ui.Setup(character);
        ui.SetPositionNextToMouse();
        ui.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        FindObjectOfType<CharacterHireRequireDescriptionUI>()?.gameObject.SetActive(false);
    }
    public void SetPositionNextToMouse()
    {
        if (imageRectTransform == null) return;
        // Convert mouse position to canvas space
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform,
            Input.mousePosition,
            null,
            out mousePos);

        // Add the offset to the mouse position
        mousePos += offset;

        // Set the anchored position based on mouse
        imageRectTransform.anchoredPosition = mousePos;

        // Clamp the position so the UI stays within the screen bounds
        Vector2 clampedPosition = imageRectTransform.anchoredPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -canvasRectTransform.sizeDelta.x / 2 + imageRectTransform.sizeDelta.x / 2, canvasRectTransform.sizeDelta.x / 2 - imageRectTransform.sizeDelta.x / 2);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -canvasRectTransform.sizeDelta.y / 2 + imageRectTransform.sizeDelta.y / 2, canvasRectTransform.sizeDelta.y / 2 - imageRectTransform.sizeDelta.y / 2);
        imageRectTransform.anchoredPosition = clampedPosition;
    }
    public Tag Use(ItemName itemName)
    {
        Tag output = Tag.Null;
        if (SOItem.ItemMap.ContainsKey(itemName))
        {
            output = SOItem.ItemMap[itemName];
            return output;
        }
        else
        {
            Debug.LogError(itemName);
            return output;
        }
    }
}
