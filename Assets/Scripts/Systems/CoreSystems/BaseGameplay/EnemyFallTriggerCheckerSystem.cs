using Components.Core;
using Components.Objects.Tags;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using Components.UnityComponents.MonoLinks;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class EnemyFallTriggerCheckerSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<GameOverZoneTag, OnTriggerEnterEvent> _filter = null;

        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int index in _filter)
            {
                GameObject collisionGameObject = _filter.Get2(index).Collider.gameObject;
                var tag = collisionGameObject.GetComponent<EnemyTagMonoLink>();
                if (tag == null)
                    continue;
                
                _world.NewEntity().Get<GameOverEvent>();
            }
        }
    }
}