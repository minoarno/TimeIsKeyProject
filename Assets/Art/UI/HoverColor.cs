using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverColor: MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    ISelectHandler,
    IDeselectHandler
{
    private Button button;
    private Graphic[] graphics;

    void Awake()
    {
        button = GetComponent<Button>();
        graphics = GetComponentsInChildren<Graphic>(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!button.interactable) return;

        SetColor(button.colors.highlightedColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!button.interactable) return;

        SetColor(button.colors.normalColor);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!button.interactable) return;

        SetColor(button.colors.pressedColor);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!button.interactable) return;

        SetColor(button.colors.highlightedColor);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (!button.interactable) return;

        SetColor(button.colors.selectedColor);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (!button.interactable) return;

        SetColor(button.colors.normalColor);
    }

    void SetColor(Color color)
    {
        foreach (Graphic graphic in graphics)
        {
            graphic.color = color;
        }
    }
}