using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _timeBetweenShoots;
    [SerializeField] private GameObject _shootPoint;
    [SerializeField] private FireArea _fireArea;

    private Queue<Enemy> _enemies;
    private Enemy _targetEnemy;
    private float _timer;
    private int _money =0;

    public UnityEvent<int> ChangeMoney;

    private void Start()
    {
        _enemies= new Queue<Enemy>();
        _timer = _timeBetweenShoots;
        ChangeMoney?.Invoke(_money);
    }

    private void Update()
    {
        if (_enemies.Count > 0 && _targetEnemy == null)
        {
            _targetEnemy = _enemies.Dequeue();
            ChangeMoney?.Invoke(_money);
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
    }

    public void GetDamage(Enemy enemy)
    {
        _health -= _targetEnemy.Damage;
        _targetEnemy.Dead();
    }

    public void AddMoney(int money)
    {
        _money += money;
    }

    public void RemoveMoney(int money)
    {
        _money -= money;
    }
}
