using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace lokpok_v2
{
    public delegate bool GetShift();
    public delegate void InLog(string text);
    public delegate void UpdateBarsHandler();

    public class LiveShell : UIElement
    {
        bool _onLeftMouseButtonDown = false;
        Live _live;
        //HpBarView _hpBar;
        Grid _grid;
        public NewHpBar NewHpBar {get; set;}
        public event UpdateBarsHandler UpdateBar;

        private bool _isSelectp;
        public bool IsSelectP
        {
            get { return this._isSelectp; }
            set
            {
                this._isSelectp = value;
                if (value)
                {
                    Storage.SelectedPlayers.Add(this);
                    foreach (var hpbar in HpBarsList)
                        Storage.SelectedHpBars.Add(hpbar);
                }
                else
                {
                    Storage.SelectedPlayers.Remove(this);
                    foreach (var hpbar in HpBarsList)
                        Storage.SelectedHpBars.Remove(hpbar);
                }
                this.InvalidateVisual();
                UpdateBar();
            }
        }

        public List<NewHpBar> HpBarsList;

        public event GetShift GetMainWindowShift;
        public event InLog MessageInLog;

        public Live GetLive { get { return _live; } }
        public Grid ShellGrid { get { return _grid; } }
        
        public LiveShell(Live live)
        {
            _live = live;
            

            //_live.HpChanged += HPChangeInBar;
            //_live.HpChanged += HPCHangeInLog;
            _live.LiveDead += Death;

            HpBarsList = new List<NewHpBar>();
            foreach (var hp in _live.HealthPointsList)
                HpBarsList.Add(new NewHpBar(80, 15, hp));

            //NewHpBar = new NewHpBar(30, 10, new HealthPoints(_live.Name, _live.HealthPointsList[0].MaxValue, HealthType.CriticalToLife));
            //NewHpBar = HpBarsList[0];
            //NewHpBar.Name = _live.Name;
            //NewHpBar.Width = 30;
            //NewHpBar.Height = 10;

            _grid = new Grid();
            _grid.RowDefinitions.Add(new RowDefinition());
            _grid.RowDefinitions.Add(new RowDefinition());

            //NewHpBar.Margin = new Thickness(0, 6, 0, 0);
            //NewHpBar.SetValue(Grid.RowProperty, 0);
            //_grid.Children.Add(NewHpBar);

            this.SetValue(Grid.RowProperty, 1);
            _grid.Children.Add(this);
        }

        private void HPChangeInBar(Live live)
        {
            //NewHpBar.Health = live.CurrentHealthPoints / live.MaxHealthPoints < 0 ? 0 : live.CurrentHealthPoints / live.MaxHealthPoints;
        }

        private void HPCHangeInLog(Live live)
        {
            string change = "";
            if (live.ChangeHP <= 0) change = " получил урон: ";
            else change = " полечился на ";
            if (MessageInLog != null) MessageInLog(live.Name + change + live.ChangeHP);
        }

        private void Death(Live live)
        {
            if (MessageInLog != null) MessageInLog(live.Name + " сдох!");
        }

        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            _onLeftMouseButtonDown = true;
        }

        protected override void OnMouseLeftButtonUp(System.Windows.Input.MouseButtonEventArgs e)
        {
                if (_onLeftMouseButtonDown)
                {
                    bool OnShiftDown = GetMainWindowShift();

                    //if (OnShiftDown) Storage.ShiftSelectPlayer((LiveShell)e.Source);
                    //else Storage.SelectPlayer((LiveShell)e.Source);

                    if (OnShiftDown) ((LiveShell)e.Source).IsSelectP = !this._isSelectp;
                    else Storage.NewSelectPlayer((LiveShell)e.Source);

                    _onLeftMouseButtonDown = false;
                }
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            //Drawler.GetDrContext(drawingContext, _live.LiveType, _live.IsSelect, _live.Name);
            Drawler.GetDrContext(drawingContext, _live.LiveType, this._isSelectp, _live.Name);
        }

        public void RePaint()
        {
            this.InvalidateVisual();
        }

    }
}
