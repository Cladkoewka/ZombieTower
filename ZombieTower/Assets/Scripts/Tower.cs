using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _health;

    private Queue<Enemy> _enemies;
    private Enemy _targetEnemy;
    //private List<Enemy> _enemyList;

    private void Start()
    {
        _enemies= new Queue<Enemy>();
        //_enemyList= new List<Enemy>();
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

        }
    }

    public void AddEnemyInQueue(Enemy enemy)
    {
        _enemies.Enqueue(enemy);
        //_enemyList.Add(enemy);
        Debug.Log("added");
    }

    public void GetDamage(Enemy enemy)
    {
        _health -= _targetEnemy.Damage;
        _targetEnemy.Dead();
    }

}
