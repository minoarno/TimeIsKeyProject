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
        FlipUpdate();
    }

    public virtual void FlipUpdate()
    {
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle == _desiredRotation) return;

        float difference = (_desiredRotation - currentAngle) % 360;
        if (difference < 0f) difference += 360;

        transform.rotation = Quaternion.Euler(0, 0, currentAngle + difference * _rotationSpeed * Time.deltaTime);
    }

    public virtual void Flip()
    {
        _desiredRotation += 180;
    }
}
