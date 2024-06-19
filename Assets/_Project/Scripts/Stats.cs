using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; private set; }
    
    [field: SerializeField] public int Health { get; private set; }
}