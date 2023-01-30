using Components.Common.Input;
using Leopotam.Ecs;
using Components.Objects.Tags;
using UnityEngine.InputSystem;

namespace Systems.InputSystems
{
    public class KeyInputSystem : IEcsPreInitSystem, IEcsRunSystem
    {
        private PlayerInput _inputSystem;
        private EcsFilter<PlayerTag> _filter = null;

        public void PreInit()
        {
            _inputSystem = new PlayerInput();
            _inputSystem.Enable();
            _inputSystem.Gameplay.Left.performed += context => OnLeft(context);
            _inputSystem.Gameplay.Right.performed += context => OnRight(context);
            _inputSystem.Gameplay.Shoot.performed += context => OnShoot(context);
        }

        public void Run()
        {
            if (_inputSystem.Gameplay.Right.WasReleasedThisFrame() || _inputSystem.Gameplay.Left.WasReleasedThisFrame())
                OnRelease();
        }

        private void OnLeft(InputAction.CallbackContext context)
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<LeftKeyDownTag>();
            }
        }
        
        private void OnRight(InputAction.CallbackContext context)
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<RightKeyDownTag>();
            }
        }
        
        private void OnRelease()
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<KeyReleasedTag>();
            }
        }
        
        private void OnShoot(InputAction.CallbackContext context)
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                entity.Get<ShootKeyDownTag>();
            }
        }
    }
}