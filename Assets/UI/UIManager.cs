using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TMPro.TMP_Text currentAgeText;
    public TMPro.TMP_Text sandTopText;
    public TMPro.TMP_Text sandBottomText;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Flip()
    {
        GameController.Instance.Flip();
    }

    private void Start()
    {
        UpdateTexts();
    }

    private void LateUpdate()
    {
        UpdateTexts();
    }

    public void UpdateTexts()
    {
        currentAgeText.text = "Age: " + GameController.Instance.CurrentPlacementType;
        sandTopText.text = "Sand left: " + GameController.Instance.TopSand;
        sandBottomText.text = "Sand gained: " + GameController.Instance.BottomSand;
    }
}
