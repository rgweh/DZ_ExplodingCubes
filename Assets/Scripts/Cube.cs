using System;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour 
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForse;
    [SerializeField] private int _generation;

    private float _scaleReduce = 2;

    public event Action<GameObject> TryDuplicateCube;
    public float ActionChance { get; private set; }

    private void OnEnable()
    {
        _generation++;

        ActionChance = 100 / _generation;

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x / _scaleReduce, scale.y / _scaleReduce, scale.z / _scaleReduce);

        var renderer = GetComponent<Renderer>();
        renderer.material.color = UnityEngine.Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        TryDuplicateCube?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
