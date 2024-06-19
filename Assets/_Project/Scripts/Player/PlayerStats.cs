using UnityEngine;

public class PlayerStats : Stats
{
    [field: SerializeField] public float Speed { get; private set; }

    [field: SerializeField] public float RotationSpeed { get; private set; }
}
