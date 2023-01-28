using Components.Common.MonoLinks;
using Components.Core;
using Leopotam.Ecs;

namespace Systems.CoreSystems.BaseGameplay
{
    public class SetActiveSystem : IEcsRunSystem
    {
        private EcsFilter<SetActiveEvent> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                ref var goLink = ref entity.Get<GameObjectLink>();

                var x = _filter.Get1(index).Value;
                
                goLink.Value.SetActive(x);

            }
        }
    }
}