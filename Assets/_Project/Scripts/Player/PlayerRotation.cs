using UnityEngine;

namespace _Project
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementDirection = new Vector3(-verticalInput, 0, horizontalInput);
            movementDirection.Normalize();

            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}