using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.GetDamage(_damage);
            Destroy(gameObject);
        }
        if (other.TryGetComponent(out Wall wall))
        {
            Destroy(gameObject);
        }
    }
}
