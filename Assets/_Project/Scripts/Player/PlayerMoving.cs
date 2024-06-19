using System;
using System.Collections;
using UnityEngine;

namespace _Project
{
    public class PlayerMoving : MonoBehaviour
    {
        private bool _isMoving;
        private bool _moved = false;

        public event Action OnMoved;

        private void Update()
        {            
            if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && _moved == false)
            {
                _moved = true;
                _isMoving = true;
                StartCoroutine(Wait());
            }
            else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                _isMoving = false;
            }
        }

        private IEnumerator Wait()
        {
            yield return new WaitUntil(() => _isMoving == false);
            OnMoved?.Invoke();

            _moved = false;
        }
    }
}