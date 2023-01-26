using Components.Core;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class DeadSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<DeadEvent> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref GameObject gameObject = ref _filter.Get1(index).Target;
                gameObject.SetActive(false);
                

            }
        }
    }
}