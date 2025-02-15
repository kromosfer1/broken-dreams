using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class SettingsPanel : PanelBase
    {
        protected override string ID => "SettingsPanel";

        public override void ShowPanel()
        {
            base.ShowPanel();
            ActionManager.GamePauseRequested?.Invoke();
        }
        public override void HidePanel()
        {
            base.HidePanel();
            ActionManager.GameResumeRequested?.Invoke();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}