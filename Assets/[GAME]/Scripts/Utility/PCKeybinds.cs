using System;
using System.Collections.Generic;
using AnilHarmandali.UnityRuntimeUI;
using UnityEngine;

public class PCKeybinds : MonoBehaviour
{
    #region PausePanel
    [Header ("PausePanel")]
    [SerializeField] private SettingsPanel _pauseScript;
    private bool isPausePanelVisible = false;
    #endregion

    private Dictionary<KeyCode, Action> keyActions;

    private void Start()
    {
        // Initialize the dictionary and map keys to actions
        keyActions = new Dictionary<KeyCode, Action>
        {
            { KeyCode.Escape, PauseGameKey },
        };
    }

    private void Update()
    {
        // Check for key presses dynamically
        foreach (var keyAction in keyActions)
        {
            if (Input.GetKeyDown(keyAction.Key))
            {
                keyAction.Value?.Invoke();
            }
        }
    }

    private void PauseGameKey()
    {
        if (_pauseScript != null)
        {
            if (isPausePanelVisible)
            {
                _pauseScript.HidePanel();
            }
            else
            {
                _pauseScript.ShowPanel();
            }

            // Toggle the state
            isPausePanelVisible = !isPausePanelVisible;
        }
        else
        {
            Debug.LogWarning("PauseScript (SettingsPanel) is not assigned in the Inspector!");
        }
    }


}
