using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnilHarmandali.UnityRuntimeUI
{
    public class MainMenuPanel : PanelBase
    {
        protected override string ID => "MainMenu";

        public override void ShowPanel()
        {
            base.ShowPanel();
        }

        public override void HidePanel()
        {
            base.HidePanel();
            ActionManager.OnGameStart?.Invoke();
        }
    }
}
