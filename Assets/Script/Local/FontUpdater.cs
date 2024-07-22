using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FontUpdater : MonoBehaviour
{
    private void Awake()
    {
        // Check if the component is a Text or TextMeshProUGUI and register it
        var textComponent = GetComponent<Text>();
        if (textComponent != null)
        {
            FontManager.RegisterTextComponent(textComponent);
        }

        var textMeshProComponent = GetComponent<TextMeshProUGUI>();
        if (textMeshProComponent != null)
        {
            FontManager.RegisterTMPTextComponent(textMeshProComponent);
        }
    }

}
