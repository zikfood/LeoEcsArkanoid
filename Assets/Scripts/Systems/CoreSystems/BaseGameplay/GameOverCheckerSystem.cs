using Components.GameStates;
using Leopotam.Ecs;
using Components.Core;
using UnityComponents.Common;
using Services;

namespace Systems.CoreSystems.BaseGameplay
{
    public class GameOverCheckerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private SceneData _sceneData;
        private PauseService _pauseService;
        private EcsWorld _world = null;
        private EcsFilter<GameOverEvent> _gameOverFilter = null;
        private EcsFilter<GameProgress> _gameProgress;

        public void Init()
        {
            _world.NewEntity().Get<GameProgress>() = new GameProgress
            {
                IsPause = true
            };
        }

        public void Run()
        {
            if (_gameOverFilter.IsEmpty()) 
                return;
			
            foreach (int index in _gameProgress)
            {
                ref GameProgress progress = ref _gameProgress.Get1(index);
                progress.IsPause = true;
                _pauseService.SetPause();
                _sceneData.Hud.ShowGameOver();
            }
        }
    }
}