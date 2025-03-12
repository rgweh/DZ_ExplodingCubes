﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeDuplicator : MonoBehaviour
{
    [SerializeField] private int _minAmount = 2;
    [SerializeField] private int _maxAmount = 6;
    
    private List<Cube> _lastCreatedCubes;

    public event UnityAction<Cube> CreatedNewCube;

    public List<Cube> GetLastDuplicated => _lastCreatedCubes;

    public void Duplicate(Cube cube)
    {
        int amount = Random.Range(_minAmount, _maxAmount);
        _lastCreatedCubes = new List<Cube>();

        for (int i = 0; i < amount; i++)
        {
            Cube newborn = Instantiate(cube);
            _lastCreatedCubes.Add(newborn);
            newborn.Init();
        }
    }
}
