using Components.Core;
using Components.Objects.Tags;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using Components.UnityComponents.MonoLinks;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class BulletCollisionCheckerSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<BulletTag, OnCollisionEnterEvent> _filter = null;

        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                var onCollisionEnterEvent = entity.Get<OnCollisionEnterEvent>();

                GameObject collisionGameObject = onCollisionEnterEvent.Collision.gameObject;
                var damagable = collisionGameObject.GetComponent<DamageableTagMonoLink>();
                if (damagable == null)
                    continue;

                ref var newEntity = ref _world.NewEntity().Get<DamageEvent>();
                newEntity.Target = collisionGameObject;
            }
        }
    }
}