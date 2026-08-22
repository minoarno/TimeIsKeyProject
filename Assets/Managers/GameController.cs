using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Age => _age;
    private int _age = 0;

    public Enums.PlacementType CurrentPlacementType => _currentPlacementType;
    private Enums.PlacementType _currentPlacementType = Enums.PlacementType.Moons;

    public int BottomSand => _bottomSand;
    private int _bottomSand = 0;
    public int TopSand => _topSand;
    private int _topSand = 0;
    [SerializeField] private int _initialSand = 500;

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
        _topSand = _initialSand;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastTimeCheck + _timeCheckDelay > Time.time) return;
        _lastTimeCheck = Time.time;

        if (_topSand < 0)
        {
            Lose();
            return;
        }

        _topSand--;
        _bottomSand++;
    }

    public void Flip()
    {
        for(int i = 0; i < _flippers.Count; i++)
        {
            _flippers[i].Flip();
        }
        _age++;
        _currentPlacementType = (Enums.PlacementType)(_age % 2);

        int tempSand = _bottomSand;
        _bottomSand = _topSand;
        _topSand = tempSand;
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
