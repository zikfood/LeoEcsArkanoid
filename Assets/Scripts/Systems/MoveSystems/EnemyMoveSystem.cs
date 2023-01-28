using Components.Objects;
using Leopotam.Ecs;
using Components.Objects.Moves;
using Components.Objects.Tags;
using UnityEngine;
using UnityComponents.Common;

namespace Systems.MoveSystems
{
    public class EnemyMoveSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<EnemyTag> _filter = null;
        private StaticData _staticData;

        private float _moveDelay;
        private float _lastTime;

        private int _movementIndex = 0;
        
        
        public void Init()
        {
            _moveDelay = _staticData.SpawnTimer;
        }

        public void Run()
        {
            _lastTime += Time.deltaTime;
            if (_lastTime > _moveDelay)
            {
                
                foreach (int index in _filter)
                {
                    ref EcsEntity entity = ref _filter.GetEntity(index);
                    ref Position position = ref entity.Get<Position>();

                    var x = _staticData.EnemyMovements[0];

                    position.Value += _staticData.EnemyMovements[_movementIndex];
                }
                
                _movementIndex++;
                if (_movementIndex >= _staticData.EnemyMovements.Length)
                    _movementIndex = 0;
                
                _lastTime -= _moveDelay;
            }
        }
    }
}