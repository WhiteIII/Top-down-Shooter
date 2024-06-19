using UnityEngine;
using DG.Tweening;

namespace _Project
{
    [CreateAssetMenu(fileName = "RandomlyMovingEnemy", menuName = "Enemy/RandomlyMovingEnemy")]

    public class RandomlyMovingEnemyData : EnemyData
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public int RepeatRate { get; private set; }
        [field: SerializeField] public float Distance { get; private set; }
        [field: SerializeField] public float Time { get; private set; }
        [field: SerializeField] public LoopType LoopType { get; private set; }
        [field: SerializeField] public GameObject _enemyPrefab { get; private set; }
    }
}