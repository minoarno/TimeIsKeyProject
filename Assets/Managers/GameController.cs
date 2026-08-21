using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Age => _age;
    private int _age = 0;

    public int Sand => _sand;
    private int _sand = 0;
    [SerializeField] private int _initialSand = 500;

    [SerializeField] private int _sandlossPerTurn = 100;

    private float _lastTimeCheck = 0;
    [SerializeField] private float _timeCheckDelay = 1f;

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
        _sand = _initialSand;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastTimeCheck + _timeCheckDelay > Time.time) return;
        _lastTimeCheck = Time.time;

        _sand--;

        if( _sand < 0 )
        {
            Lose();
        }
    }

    public void Flip()
    {
        for(int i = 0; i < _flippers.Count; i++)
        {
            _flippers[i].Flip();
        }
        _age++;
        _sand -= _sandlossPerTurn;
    }

    public void SubscribeFlipper(FlipBehaviour flipper)
    {
        _flippers.Add(flipper);
    }


    public void UnsubscribeFlipper(FlipBehaviour flipper)
    {
        _flippers.Remove(flipper);
    }

    private void Lose()
    {
        
    }
}
