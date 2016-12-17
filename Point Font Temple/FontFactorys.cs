using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_Font_Temple
{
    class FontFactorys<T>
    {
        private List<T> list = new List<T>();

        public void Add(T _element)
        {
            this.list.Add(_element);
        }
        public void Remove(T _element)
        {
            this.list.Remove(_element);
        }

        public void Show()
        {
            foreach(T t in this.list)
            {
                //
            }
        }
    }
}
