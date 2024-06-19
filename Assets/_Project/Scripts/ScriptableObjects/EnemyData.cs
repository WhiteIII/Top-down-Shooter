using UnityEngine;

namespace _Project
{
    abstract public class EnemyData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
    }
}