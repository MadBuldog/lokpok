using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lokpok_v2
{
    public interface IData
    {
        List<Live> Load();
    }

    class CodeData : IData
    {
        public List<Live> Load()
        {
            List<Live> Data = new List<Live>();

            Data.Add(new Humanoid("Вася", 100, 5, 5, 3, true, true, false));
            Data.Add(new Humanoid("Петя", 100, 50, 5, 3, true, true));
            Data.Add(new Dog("Бобик", 100, 105, 5, 5, true, true));

            return Data;
        }
    }

}
