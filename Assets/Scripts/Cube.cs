using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour 
{
    [SerializeField] private int _generation;

    private float _actionChance;
    private float _scaleReduce = 2;

    public event UnityAction<Cube> DuplicateCube;
    public event UnityAction ExplodeCube;
    
    public void Init()
    {
        _generation++;

        _actionChance = 100 / _generation;

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x / _scaleReduce, scale.y / _scaleReduce, scale.z / _scaleReduce);

        var renderer = GetComponent<Renderer>();
        renderer.material.color = Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        if(TryDuplicate())
            Explode();

        Destroy(gameObject);
    }

    private bool TryDuplicate()
    {
        List<Cube> cubes = new List<Cube>();

        if (Random.Range(0, 100) <= _actionChance)
        {
            DuplicateCube?.Invoke(this);
            return true;
        }

        return false;
    }

    private void Explode()
    {
        ExplodeCube?.Invoke();
    }
}
