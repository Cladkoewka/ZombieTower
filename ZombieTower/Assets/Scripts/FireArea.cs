using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    [SerializeField] private float _radius;


    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.localScale = new Vector3(_radius, 0.01f, _radius);
    }
}
