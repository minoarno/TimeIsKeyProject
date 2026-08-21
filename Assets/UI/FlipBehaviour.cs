using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class FlipBehaviour : MonoBehaviour
{
    float _desiredRotation = 0f;
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        GameController.Instance.SubscribeFlipper(this);
    }

    private void OnDestroy()
    {
        GameController.Instance.UnsubscribeFlipper(this);
    }

    private void Update()
    {
        float currentAngle = transform.eulerAngles.z;
        float difference = (_desiredRotation - currentAngle) % 360;
        if (difference < 0f) difference += 360;

        transform.rotation = Quaternion.Euler(0, 0, currentAngle + difference * _rotationSpeed * Time.deltaTime);
    }

    public void Flip()
    {
        _desiredRotation += 180;
    }
}
