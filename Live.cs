using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace lokpok_v2
{
    public enum LIVE_TYPE
    {
        HUMANOID = 1,
        DOG = 2
    }

    public enum DIRECTION
    {
        RIGHT = 1,
        LEFT = 2,
        UP = 3,
        DOWN = 4,
        RIGHTUP = 5,
        RIGHTDOWN = 6,
        LEFTUP = 7,
        LEFTDOWN = 8
    }

    //public delegate void HPChangeHandler(Live live);
    public delegate void DeathHandler(Live live);

    public class Live
    {
        protected string _name;
        protected LIVE_TYPE _type;
        //protected float _healthPoints;
        //protected float _maxHealthPoints;
        protected double _left;
        protected double _top;
        protected float _speed = 2;
        protected bool _isMove;
        protected bool _isControlPlayer;
        protected bool _isSelectPlayer;
        protected bool _isDead;
        protected List<HealthPoints> _healthPointsList;

        //public event HPChangeHandler HpChanged;
        public event DeathHandler LiveDead;

        public string Name { get { return _name; } }
        public LIVE_TYPE LiveType { get { return _type; } }
        public double GetLeft { get { return _left; } }
        public double GetTop { get { return _top; } }
        //public float CurrentHealthPoints { get { return _healthPoints; } }
        //public float MaxHealthPoints { get { return _maxHealthPoints; } }
        public float ChangeHP { get; private set; }
        public bool IsSelect { get { return _isSelectPlayer; } set { _isSelectPlayer = value; } }
        public List<HealthPoints> HealthPointsList { get { return _healthPointsList; } }

        public Live(LIVE_TYPE pType, string name, float hp, double x, double y, float speed, bool isMove, bool isControlPlayer, bool isSelectPlayer = false)
        {
            _name = name;
            _type = pType;
            //_maxHealthPoints = hp;
            //_healthPoints = hp;
            _left = x;
            _top = y;
            _speed = speed;
            _isMove = isMove;
            _isControlPlayer = isControlPlayer;
            _isSelectPlayer = isSelectPlayer;
            _isDead = false;
        }

        public void Move(DIRECTION _direction)
        {
            if (_isMove) 
            {
                float _modificatorX = 0;
                float _modificatorY = 0;

                switch (_direction)
                {
                    case DIRECTION.RIGHT:
                        {
                            _modificatorX = 1;
                            break;
                        }
                    case DIRECTION.LEFT:
                        {
                            _modificatorX = -1;
                            break;
                        }
                    case DIRECTION.UP:
                        {
                            _modificatorY = -1;
                            break;
                        }
                    case DIRECTION.DOWN:
                        {
                            _modificatorY = 1;
                            break;
                        }
                    case DIRECTION.RIGHTDOWN:
                        {
                            _modificatorX = 1;
                            _modificatorY = 1;
                            break;
                        }
                }
                _left += _modificatorX * _speed;
                _top += _modificatorY * _speed;
            }
        }

        public void ChangeHealthPoints(int index, float change)
        {
            if (!_isDead)
            {
                ChangeHP = change;
                _healthPointsList[index].Value += change;

                //if (HpChanged != null) HpChanged(this);

                if (_healthPointsList[index].HealthType == HealthType.CriticalToLife && _healthPointsList[index].Value <= 0) Die();
                if (_healthPointsList[index].HealthType == HealthType.CriticalToMove && _healthPointsList[index].Value <= 0) _isMove = false;
            }
        }

        private void Die()
        {
            if (!_isDead)
            {
                if (_isMove) _isMove = false;
                if (LiveDead != null) LiveDead(this);
                _isDead = true;
            }
        }
    }

    public class Humanoid : Live
    {
        public Humanoid(string name, float hp, double x, double y, float speed, bool isMove, bool isControlPlayer, bool isSelectPlayer = false)
            : base(LIVE_TYPE.HUMANOID, name, hp, x, y, speed, isMove, isControlPlayer, isSelectPlayer)     
        {
            _healthPointsList = new List<HealthPoints>() {
                new HealthPoints("Общее" , hp, HealthType.CriticalToLife),
                new HealthPoints("Голова", hp, HealthType.CriticalToLife),
                new HealthPoints("Грудь", hp, HealthType.CriticalToLife),
                new HealthPoints("Живот", hp, HealthType.CriticalToLife),
                new HealthPoints("Правая рука", hp, HealthType.NoneCritical),
                new HealthPoints("Левая рука", hp, HealthType.NoneCritical),
                new HealthPoints("Правая нога", hp, HealthType.CriticalToMove),
                new HealthPoints("Левая нога", hp, HealthType.CriticalToMove)
            };
        }
    }

    public class Dog : Live
    {
        public Dog(string name, float hp, double x, double y, float speed, bool isMove, bool isControlPlayer, bool isSelectPlayer = false)
            : base(LIVE_TYPE.DOG, name, hp, x, y, speed, isMove, isControlPlayer, isSelectPlayer)     
        {
            _healthPointsList = new List<HealthPoints>() {
                new HealthPoints("Общее" , hp, HealthType.CriticalToLife),
                new HealthPoints("Голова", hp, HealthType.CriticalToLife),
                new HealthPoints("Грудь", hp, HealthType.CriticalToLife),
                new HealthPoints("Живот", hp, HealthType.CriticalToLife),
                new HealthPoints("Правая п лапа", hp, HealthType.CriticalToMove),
                new HealthPoints("Левая п лапа", hp, HealthType.CriticalToMove),
                new HealthPoints("Правая з лапа", hp, HealthType.CriticalToMove),
                new HealthPoints("Левая з лапа", hp, HealthType.CriticalToMove),
                new HealthPoints("Хвост", hp, HealthType.NoneCritical)
            };
        }
    }


}
