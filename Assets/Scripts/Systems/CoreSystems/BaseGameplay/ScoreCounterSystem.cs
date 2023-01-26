using Components.Core;
using Components.UnityComponents.MonoLinks;
using Leopotam.Ecs;
using Services;
using UnityComponents.Common;

namespace Systems.CoreSystems.BaseGameplay
{
    public class ScoreCounterSystem : IEcsRunSystem, IEcsInitSystem
    {
        private SceneData _sceneData;
        private ScoreService _score;
        private EcsWorld _world = null;
        private EcsFilter<DeadEvent> _enemyDeadScoreFilter = null;

        private int _maxScore;

        public void Init()
        {
            _maxScore = _sceneData.EnemyLinesAmount * _sceneData.EnemyAmountInLine;
        }

        public void Run()
        {
            if (_enemyDeadScoreFilter.IsEmpty()) 
                return;

            foreach (int index in _enemyDeadScoreFilter)
            {
                var go = _enemyDeadScoreFilter.Get1(index).Target;
                if (go.TryGetComponent(out EnemyTagMonoLink i)) 
                {
                    _score.AddScore(1);
                    _sceneData.Hud.SetScore(_score.Score);

                    if (_score.Score >= _maxScore)
                    {
                        _world.NewEntity().Get<GameWinEvent>();
                    }
                }
            }
        }
    }
}