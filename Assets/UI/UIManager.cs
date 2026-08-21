using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMPro.TMP_Text sandText;

    public void Flip()
    {
        GameController.Instance.Flip();
    }

    private void Start()
    {
        UpdateSand();
    }

    private void LateUpdate()
    {
        UpdateSand();
    }

    public void UpdateSand()
    {
        sandText.text = "Sand: " + GameController.Instance.Sand;
    }
}
