using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _health;
    [SerializeField] private int _reward;

    public float Damage => _damage;

    private Tower _tower;

    private void Start()
    {
        _tower = FindObjectOfType<Tower>();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _tower.transform.position, _speed * Time.deltaTime);
        transform.LookAt(_tower.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out FireArea fireArea))
        {
            _tower.AddEnemyInQueue(this);
        }
        if(other.TryGetComponent(out Tower tower))
        {
            _tower.GetDamage(this);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
        _tower.AddMoney(_reward);
    }


    public void GetDamage(float _damage)
    {
        _health -= _damage;
        if(_health <= 0)
        {
            Dead();
        }
    }
}
