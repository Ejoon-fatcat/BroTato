using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommonButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    private TextMeshProUGUI text;

    //获取组件
    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color(255, 255, 255);
        text.color = Color.black;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.black;
        text.color = new Color(255, 255, 255);
    }
}
