using UnityEngine;

namespace _Project
{
    [RequireComponent(typeof(Animator))]
    
    public class PlayerWalkAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        private void Update()
        {
            _animator.SetBool("isWalked", Input.GetAxis("Horizontal") != 0
                || Input.GetAxis("Vertical") != 0);
        }
    }
}