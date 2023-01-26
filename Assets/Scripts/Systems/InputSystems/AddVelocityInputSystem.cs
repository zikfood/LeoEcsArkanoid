using Components.Common.Input;
using Components.Objects.Moves;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.InputSystems
{
    public class AddVelocityInputSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        private EcsFilter<LeftKeyDownTag> _leftFilter = null;
        private EcsFilter<RightKeyDownTag> _rightFilter = null;
        private EcsFilter<KeyReleasedTag> _releasedFilter = null;

        public void Run()
        {
            AddVelocity(_rightFilter, _staticData.PlayerAddForce);
            AddVelocity(_leftFilter, - _staticData.PlayerAddForce);
            OnKeyReleased(_releasedFilter);
        }

        private void AddVelocity(EcsFilter filter, Vector3 velocity)
        {
            foreach (int index in filter)
            {
                ref EcsEntity entity = ref filter.GetEntity(index);
                ref Velocity entVelocity = ref entity.Get<Velocity>();
                entVelocity.Value += velocity;
            }
        }

        private void OnKeyReleased(EcsFilter filter)
        {
            foreach (int index in filter)
            {
                ref EcsEntity entity = ref filter.GetEntity(index);
                ref Velocity entVelocity = ref entity.Get<Velocity>();
                entVelocity.Value = Vector3.zero;
            }
        }
    }
}