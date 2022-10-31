using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace FortMarion.Localization
{
    public class TextManager
    {
        private Dictionary<string, string> _gameTexts;
        public string Locale { get; private set; }

        public TextManager(string locale = "en-us")
        {
            _gameTexts = new Dictionary<string, string>();
            Locale = locale;
        }

        public string GetText(string id)
        {
            return _gameTexts.TryGetValue(id, out var str) ? str : null;
        }
        
        public string GetTextOrDefault(string id, string defaultValue)
        {
            return _gameTexts.TryGetValue(id, out var str) ? str : defaultValue;
        }

        public void AddText(string id, string value)
        {
            _gameTexts[id] = value;
        }

        public void UpdateLanguage(string locale)
        {
            if (Locale == locale) return;
            Locale = locale;
            _gameTexts.Clear();
            LoadGameTexts();
        }

        public void LoadGameTexts()
        {
            Debug.Log(Application.dataPath);
            _gameTexts = File.ReadLines(Path.Combine(Application.dataPath, $"Localization/strings.{Locale}.csv"))
                .Select(line => line.Split(',')).ToDictionary(line => line[0], line=> line[1]);
        }
    }
}