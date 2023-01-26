using Components.Common;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class EnemySpawner : IEcsInitSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _world = null;
        private Vector3 _spawnPosition;
        
        public void Init()
        {
            _spawnPosition = _sceneData.SpawnEnemyPosition.position;
            for (int y = 0; y < _sceneData.EnemyLinesAmount; y++)
            {
                _spawnPosition.y += _sceneData.DistanceBetweenLines;
                for (int i = 0; i < _sceneData.EnemyAmountInLine; i++)
                {
                    _spawnPosition.x += _sceneData.DistanceBetweenEnemies;
                    _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
                    {
                        Prefab = _staticData.ObstaclePrefab,
                        Position = _spawnPosition,
                        Rotation = Quaternion.identity,
                        Parent = null
                    };
                }

                _spawnPosition.x = _sceneData.SpawnEnemyPosition.position.x;
            }

        }
    }
}