using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _timeBetweenShoots;
    [SerializeField] private GameObject _shootPoint;

    private Queue<Enemy> _enemies;
    private Enemy _targetEnemy;
    private float _timer;

    private void Start()
    {
        _enemies= new Queue<Enemy>();
        _timer = 0;
    }

    private void Update()
    {
        if (_enemies.Count > 0 && _targetEnemy == null)
        {
            _targetEnemy = _enemies.Dequeue();
        }

        if (_targetEnemy != null)
        {
            transform.LookAt(_targetEnemy.transform);
            if (_timer > _timeBetweenShoots)
            {
                Instantiate(_bullet, _shootPoint.transform.position, transform.rotation);
                _timer = 0;
            }
            _timer += Time.deltaTime;
        }
    }

    public void AddEnemyInQueue(Enemy enemy)
    {
        _enemies.Enqueue(enemy);
        Debug.Log("added");
    }

    public void GetDamage(Enemy enemy)
    {
        _health -= _targetEnemy.Damage;
        _targetEnemy.Dead();
    }


}
