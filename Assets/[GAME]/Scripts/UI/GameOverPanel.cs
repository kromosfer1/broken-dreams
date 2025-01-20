using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class GameOverPanel : PanelBase
    {
        protected override string ID => "GameOverPanel";

        //[SerializeField] private int _currentLevelIndex;

        public override void ShowPanel()
        {
            base.ShowPanel();
        }
        public override void HidePanel()
        {
            base.HidePanel();
            ActionManager.OnReviveRequested?.Invoke();
        }
        //public void RestartLevel()
        //{
        //    SceneManager.LoadScene(_currentLevelIndex);
        //}
    }
}
