using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NexusForge.UI
{
    /// <summary>
    /// In-game developer console for executing debug commands at runtime.
    /// Toggle with backtick (`). Supports command registration and history.
    /// </summary>
    public class DevConsole : MonoBehaviour
    {
        [SerializeField] private GameObject _consolePanel;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TextMeshProUGUI _outputText;
        [SerializeField] private int _maxOutputLines = 100;

        private readonly Dictionary<string, Action<string[]>> _commands = new();
        private readonly List<string> _history = new();
        private int _historyIndex;

        private void Awake()
        {
            RegisterDefaultCommands();
        }

        private void RegisterDefaultCommands()
        {
            RegisterCommand("help", _ => PrintAllCommands(), "List all available commands");
            RegisterCommand("clear", _ => ClearOutput(), "Clear console output");
            RegisterCommand("timescale", args =>
            {
                if (args.Length > 0 && float.TryParse(args[0], out float scale))
                    Time.timeScale = scale;
                Log($"TimeScale: {Time.timeScale}");
            }, "Set time scale (e.g., timescale 0.5)");
            // TODO: Add teleport, spawn, god, noclip, weather, time commands
        }

        /// <summary>Register a new console command.</summary>
        public void RegisterCommand(string name, Action<string[]> action, string description = "")
        {
            _commands[name.ToLower()] = action;
        }

        /// <summary>Execute a command string.</summary>
        public void Execute(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return;

            _history.Add(input);
            _historyIndex = _history.Count;
            Log($"> {input}");

            var parts = input.Trim().Split(' ');
            var cmd = parts[0].ToLower();
            var args = parts.Length > 1 ? parts[1..] : Array.Empty<string>();

            if (_commands.TryGetValue(cmd, out var action))
                action(args);
            else
                Log($"Unknown command: {cmd}");
        }

        /// <summary>Print a line to the console output.</summary>
        public void Log(string message)
        {
            if (_outputText != null)
                _outputText.text += message + "\n";
            // TODO: Trim to _maxOutputLines
        }

        /// <summary>Toggle console visibility.</summary>
        public void Toggle()
        {
            if (_consolePanel != null)
            {
                _consolePanel.SetActive(!_consolePanel.activeSelf);
                if (_consolePanel.activeSelf && _inputField != null)
                    _inputField.ActivateInputField();
            }
        }

        private void PrintAllCommands()
        {
            Log("Available commands:");
            foreach (var cmd in _commands.Keys)
                Log($"  {cmd}");
        }

        private void ClearOutput()
        {
            if (_outputText != null)
                _outputText.text = string.Empty;
        }
    }
}
