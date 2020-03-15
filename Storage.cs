using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lokpok_v2
{
    public static class Storage
    {
        static List<LiveShell> _lives = new List<LiveShell>();
        static List<LiveShell> _selectedPlayers = new List<LiveShell>();
        static List<NewHpBar> _selectedHpBars = new List<NewHpBar>();

        public static List<LiveShell> SelectedPlayers { get { return _selectedPlayers; } }
        public static List<NewHpBar> SelectedHpBars { get { return _selectedHpBars; } }

        public static void AddLive(LiveShell _player)
        {
            _lives.Add(_player);
        }

        public static void ShiftSelectPlayer(LiveShell _live)
        {
                if (_selectedPlayers.Contains(_live))
                {
                    _selectedPlayers.Remove(_live);
                    _live.GetLive.IsSelect = false;
                }
                else
                {
                    _selectedPlayers.Add(_live);
                    _live.GetLive.IsSelect = true;
                }
                _live.RePaint();
        }

        public static void SelectPlayer(LiveShell _live)
        {
            List<LiveShell> _toRePaint = new List<LiveShell>(_selectedPlayers);

            foreach (LiveShell _liveController in _selectedPlayers)
                _liveController.GetLive.IsSelect = false;

            _selectedPlayers.Clear();
            _selectedPlayers.Add(_live);
            _live.GetLive.IsSelect = true;

            _toRePaint.Add(_live);
            foreach (LiveShell _liveController in _toRePaint)
            {
                _liveController.RePaint();
            }
        }

        public static void NewSelectPlayer(LiveShell _live)
        {
            while (_selectedPlayers.Count > 0)
            {
                LiveShell _toRem = _selectedPlayers.First();
                _toRem.IsSelectP = false;
            }
            _live.IsSelectP = true;
        }

    }

}
