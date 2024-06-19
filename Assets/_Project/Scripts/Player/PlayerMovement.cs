using UnityEngine;
using Zenject;

namespace _Project
{
    [RequireComponent(typeof(CharacterController))]
    
    public class PlayerMovement : MonoBehaviour
    {     
        [Inject] private PlayerStats _playerStats;
        
        private CharacterController _controller;

        private void Awake() =>
            _controller = GetComponent<CharacterController>();

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            _controller.Move(move * _playerStats.Speed * Time.deltaTime);
        }
    }
}