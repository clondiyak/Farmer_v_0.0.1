using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropControl : MonoBehaviour
{
    [SerializeField] private float _timeTakes = 10;
    public bool _stateCrop;
    private Renderer _renderer;

    private void Start()
    {
        StartCoroutine(Grow());
        _renderer = GetComponent<Renderer>();
        transform.localScale = Vector3.one/2;
        _renderer.material.color = Color.yellow;
    }

    private IEnumerator Grow()
    {
        if (!_stateCrop)
        {
            yield return new WaitForSeconds(_timeTakes);
            Grown();
        }
    }

    private void Grown()
    {
        _stateCrop = true;
        transform.localScale = Vector3.one;
        _renderer.material.color = Color.green;
    }
}