using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lokpok_v2
{
    public enum HealthType
    {
        CriticalToLife = 1,
        CriticalToMove = 2,
        NoneCritical = 3
    }

    public class HealthPoints
    {
        public delegate void HPChangeHandler();
        public event HPChangeHandler HpChanged;

        private string _name;
        
        private float _maxValue;
        private float _currentValue;
        private float _oldCurrentValue;
        private float _changeValue;
        private HealthType _healthType;

        public string Name { get { return _name; } }
        public float MaxValue { get { return _maxValue; } }
        public float CurrentValue { get { return _currentValue; } }
        public float ChangeValue { get { return _changeValue; } }
        public HealthType HealthType {  get { return _healthType; } }

        public float Value
        {
            get { return _currentValue; }
            set
            {
                _oldCurrentValue = _currentValue;
                _currentValue = value;
                _changeValue = _currentValue - _oldCurrentValue;
                if (HpChanged != null) HpChanged();
                //OnChangeValue();
            }
        }

        public HealthPoints(string name, float maxvalue, HealthType isCritical)
        {
            _name = name;
            _maxValue = maxvalue;
            _currentValue = maxvalue;
            _healthType = isCritical;
        }

        //private void OnChangeValue()
        //{
        //    _changeValue = _currentValue - _oldCurrentValue;
        //    if (HpChanged != null) HpChanged(this);
        //}
    }
}
