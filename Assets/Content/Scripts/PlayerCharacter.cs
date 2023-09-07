using System;
using Cinemachine;
using UnityEngine;

namespace Scripts
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private CharacterController controller;
        [SerializeField] private float speed = 1F;

        private CinemachinePOV _pov;
        private bool _canAct = true;

        public bool CanAct
        {
            get => _canAct;
            set
            {
                _canAct = value;
                virtualCamera.enabled = _canAct;
            }
        }

        public void Setup(PlayerData data)
        {
            transform.position = data.position;
            _pov.m_VerticalAxis.Value = data.rotation.x;
            _pov.m_HorizontalAxis.Value = data.rotation.y;
        }

        private void Awake()
        {
            _pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        }

        private void Update()
        {
            if (!CanAct)
            {
                return;
            }

            HandleFacing();
            HandleMovement();
        }

        private void HandleFacing()
        {
            if (Input.GetMouseButton(0))
            {
                _pov.m_HorizontalAxis.m_InputAxisName = "Mouse X";
                _pov.m_VerticalAxis.m_InputAxisName = "Mouse Y";
            }
            else
            {
                _pov.m_HorizontalAxis.m_InputAxisName = string.Empty;
                _pov.m_VerticalAxis.m_InputAxisName = string.Empty;
                _pov.m_HorizontalAxis.m_InputAxisValue = 0;
                _pov.m_VerticalAxis.m_InputAxisValue = 0;
            }

            controller.transform.rotation = playerCamera.transform.rotation;
        }

        private void HandleMovement()
        {
            var direction = Vector3Int.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction.z += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction.z += -1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction.x += -1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction.x += 1;
            }

            if (direction == Vector3Int.zero)
            {
                return;
            }

            var heading = playerCamera.transform.rotation * direction;
            heading.y = 0;

            controller.Move(heading * (speed * Time.deltaTime));
        }
    }
}