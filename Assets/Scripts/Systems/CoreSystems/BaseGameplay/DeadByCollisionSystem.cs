using Components.Core;
using Components.Objects.Tags;
using Components.PhysicsEvents;
using Leopotam.Ecs;

namespace Systems.CoreSystems.BaseGameplay
{
    public class DeadByCollisionSystem: IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<OnCollisionEnterEvent, DeadOnCollisionTag> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                if (!_filter.IsEmpty())
                {
                    ref var newEntity = ref _world.NewEntity().Get<DeadEvent>();
                    newEntity.Target = _filter.Get1(index).Sender;
                }
            }
        }
    }
}