﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour 
{
    [SerializeField] private int _generation;

    private float _actionChance;
    private float _scaleReduce = 2;
    private int _actionChanceRangeMax = 101;
    private int _actionChanceRangeMin = 0;

    public event UnityAction<Cube> Duplicating;
    public event UnityAction<Cube> Exploding;

    void OnMouseUpAsButton()
    {
        if(TryDuplicate())
            Explode();

        Destroy(gameObject);
    }

    public void Init()
    {
        _generation++;

        _actionChance = 100 / _generation;

        Vector3 scale = transform.localScale;
        transform.localScale = scale/_scaleReduce;

        var renderer = GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }

    private bool TryDuplicate()
    {
        if (Random.Range(_actionChanceRangeMin, _actionChanceRangeMax) <= _actionChance)
        {
            Duplicating?.Invoke(this);
            return true;
        }

        return false;
    }

    private void Explode()
    {
        Exploding?.Invoke(this);
    }
}
