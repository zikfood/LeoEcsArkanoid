using Components.Core;
using Components.Objects;
using Leopotam.Ecs;

namespace Systems.CoreSystems.BaseGameplay
{
    public class DamageSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<DamageEvent> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                ref Health health = ref entity.Get<Health>();
                health.Value--;
                if (health.Value < 0)
                {
                    ref var newEntity = ref _world.NewEntity().Get<DeadEvent>();
                    newEntity.Target = _filter.Get1(index).Target;
                }

            }
        }
    }
}