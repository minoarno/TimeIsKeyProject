using System;
using UnityEngine;

public class SandDisplayer : MonoBehaviour
{
    SpriteRenderer sprite;

    [Header("Moons")]
    [SerializeField] float moonsTopValue = 0f;
    [SerializeField] float moonsBottomValue = -2.5f;
    [Header("Stars")]
    [SerializeField] float starsTopValue = 3f;
    [SerializeField] float starsBottomValue = 0f;

    [SerializeField] Enums.PlacementType placementType;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        float bottomValue = (placementType == GameController.Instance.CurrentPlacementType) ? moonsBottomValue : starsBottomValue;
        float topValue = (placementType == GameController.Instance.CurrentPlacementType) ? moonsTopValue : starsTopValue;
        propertyBlock.SetFloat("Bottom", bottomValue);
        propertyBlock.SetFloat("Top", topValue);
        sprite.SetPropertyBlock(propertyBlock);
    }

    private void Update()
    {
        if (placementType == GameController.Instance.CurrentPlacementType)
        {
            UpdateMaterial(GameController.Instance.BottomSand);
        }
        else
        {
            UpdateMaterial(GameController.Instance.TopSand);
        }
    }

    public void UpdateMaterial(int sandAmount)
    {
        float bottomValue = (placementType == GameController.Instance.CurrentPlacementType) ? moonsBottomValue : starsBottomValue;
        float topValue = (placementType == GameController.Instance.CurrentPlacementType) ? moonsTopValue : starsTopValue;

        sprite.material.SetFloat("_Bottom", bottomValue);

        float value = Mathf.Lerp(bottomValue, topValue, (float)(sandAmount / (float)GameController.Instance.MaxSand));
        if(value > topValue) value = topValue;
        if (value < bottomValue + .01f) value = bottomValue + 0.01f;

        sprite.material.SetFloat("_Top", value);
    }
}
