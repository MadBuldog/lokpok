using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace lokpok_v2
{
    class Presenter
    {
        List<Live> _lives;
        Canvas _canvas;

        public Presenter(LokPokWindow _window, IData _data)
        {
            _lives = _data.Load();
            _canvas = _window.LokpokCanvas;
            _window.Move += this.Move;

            //_window.Move += (DIRECTION direction) =>
            //{
            //    foreach (LiveShell _currentCharacter in Storage.SelectedPlayers)
            //    {
            //        _currentCharacter.GetLive.Move(direction);
            //        Canvas.SetLeft(_currentCharacter, _currentCharacter.GetLive.GetLeft);
            //        Canvas.SetTop(_currentCharacter, _currentCharacter.GetLive.GetTop);
            //        _currentCharacter.GetLive.ChangeHealthPoints(-10);
            //    }
            //};

            foreach (Live _live in _lives)
            {
                LiveShell _liveShell = new LiveShell(_live);
                Storage.AddLive(_liveShell);

                _liveShell.GetMainWindowShift += _window.GetShiftDown;
                _liveShell.MessageInLog += _window.PrintInLog;

                _liveShell.UpdateBar += () =>
                {
                    _window.HpBarsStackPanel1.Children.Clear();
                    //MessageBox.Show(Storage.SelectedHpBars.Count.ToString());
                    foreach (var hpbar in _liveShell.HpBarsList)
                        _window.HpBarsStackPanel1.Children.Add(hpbar);
                };

                _canvas.Children.Add(_liveShell.ShellGrid);
                Canvas.SetLeft(_liveShell.ShellGrid, _live.GetLeft);
                Canvas.SetTop(_liveShell.ShellGrid, _live.GetTop);
            }
        }

        private void Move(DIRECTION direction)
        {
            foreach (LiveShell _currentCharacter in Storage.SelectedPlayers)
            {
                _currentCharacter.GetLive.Move(direction);
                Canvas.SetLeft(_currentCharacter.ShellGrid, _currentCharacter.GetLive.GetLeft);
                Canvas.SetTop(_currentCharacter.ShellGrid, _currentCharacter.GetLive.GetTop);

                _currentCharacter.GetLive.ChangeHealthPoints(0, -1);
                _currentCharacter.GetLive.ChangeHealthPoints(5, -6);
                _currentCharacter.GetLive.ChangeHealthPoints(7, -5);
                _currentCharacter.GetLive.ChangeHealthPoints(2, -3);
                _currentCharacter.GetLive.ChangeHealthPoints(3, -2);
            }
        }
    }
}
