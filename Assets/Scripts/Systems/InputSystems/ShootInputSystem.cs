using Components.Common.Input;
using Components.Common.MonoLinks;
using Components.Objects;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;
using Components.Core;

namespace Systems.InputSystems
{
    public class ShootInputSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        private EcsFilter<PlayerTag> _filter = null;
        private EcsFilter<BulletTag, IsActiveLink> _bulletfilter = null;
        private EcsFilter<ShootKeyDownTag> _shootFilter = null;

        public void Run()
        {
            foreach (int index in _shootFilter)
            {
                var bullet = _bulletfilter.GetEntity(index);
                var bulletGo = bullet.Get<GameObjectLink>().Value;
                if (!bulletGo.activeSelf)
                {
                    ref var x = ref bullet.Get<Position>();
                    ref EcsEntity playerEntity = ref _filter.GetEntity(0);
                    var y = playerEntity.Get<Position>();
                    x.Value = y.Value + Vector3.up * 1.5f;
                    
                    bullet.Get<SetActiveEvent>() = new SetActiveEvent {Value = true};
                }
            }
        
        }
    }
}