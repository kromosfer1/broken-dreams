using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class NextLevelPanel : PanelBase
    {
        protected override string ID => "NextLevelPanel";

        //[SerializeField] private int _currentLevelIndex;

        public override void ShowPanel()
        {
            base.ShowPanel();
        }
        public override void HidePanel()
        {
            base.HidePanel();
        }
        //public void RestartLevel()
        //{
        //    SceneManager.LoadScene(_currentLevelIndex);
        //}
    }
}
