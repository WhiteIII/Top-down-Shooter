using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project
{
    [CreateAssetMenu(fileName = "MeleeEnemy", menuName = "Enemy/MeleeEnemy")]

    public class MeleeEnemyData : EnemyData
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public GameObject _enemyPrefab { get; private set; }
    }
}