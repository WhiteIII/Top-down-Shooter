using UnityEngine;

namespace _Project
{
    public class PlayerShootAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private PlayerAttackArea _playerAttackArea;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            _playerAttack.Shooting += ShootAnimation;
        }

        private void OnDestroy()
        {
            _playerAttack.Shooting -= ShootAnimation;
        }

        private void Update()
        {
            _animator.SetBool("isAttacking", 
                _playerAttackArea.AreaList.Count > 0);
        }

        private void ShootAnimation()
        {
            _animator.SetTrigger("Shoot");
        }
    }
}