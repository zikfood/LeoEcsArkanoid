using Components.GameStates;
using Leopotam.Ecs;
using Components.Core;
using UnityComponents.Common;
using Services;

namespace Systems.CoreSystems.BaseGameplay
{
    public class GameWinSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private PauseService _pauseService;
        private EcsFilter<GameWinEvent> _gameWinFilter = null;
        private EcsFilter<GameProgress> _gameProgress;

        public void Run()
        {
            if (_gameWinFilter.IsEmpty()) 
                return;
			
            foreach (int index in _gameProgress)
            {
                ref GameProgress progress = ref _gameProgress.Get1(index);
                progress.IsPause = true;
                _pauseService.SetPause();
                _sceneData.Hud.ShowGameWin();
            }
        }
    }
}