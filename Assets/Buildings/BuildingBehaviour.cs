using Enums;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
    public float height;
    
    public BuildingType type;
    public PlacementType placement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.CurrentPlacementType == placement) return;
    }
}
