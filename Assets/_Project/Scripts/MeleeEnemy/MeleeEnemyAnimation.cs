using UnityEngine;

namespace _Project
{
    [RequireComponent(typeof(Animator))]
    public class MeleeEnemyAnimation : MonoBehaviour
    {
        [SerializeField] private MeleeDealingDamageAera _meleeDealingDamageAera;
        
        private Animator _animator;

        private void Awake()
        {
            _meleeDealingDamageAera.EnteredTheAttackZone += AnimatorStand;
            _meleeDealingDamageAera.ExitFromTheAttackZone += AnimatorMove;
            
            _animator = GetComponent<Animator>();
        }

        private void OnDestroy()
        {
            _meleeDealingDamageAera.EnteredTheAttackZone -= AnimatorStand;
            _meleeDealingDamageAera.ExitFromTheAttackZone -= AnimatorMove;
        }

        private void AnimatorMove()
        {
            _animator.SetBool("isWalked", true);
        }

        private void AnimatorStand()
        {
            _animator.SetBool("isWalked", false);
        }
    }
}