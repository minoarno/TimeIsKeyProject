using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Age => _age;
    private int _age = 0;

    private List<FlipBehaviour> _flippers = new();

    public static GameController Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip()
    {
        for(int i = 0; i < _flippers.Count; i++)
        {
            _flippers[i].Flip();
        }
        _age++;
    }

    public void SubscribeFlipper(FlipBehaviour flipper)
    {
        _flippers.Add(flipper);
    }


    public void UnsubscribeFlipper(FlipBehaviour flipper)
    {
        _flippers.Remove(flipper);
    }
}
