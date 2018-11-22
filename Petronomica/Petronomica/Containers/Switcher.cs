using System;
using System.Collections.Generic;

namespace Containers
{
    public class Switcher<T>
    {
        public List<T> ObjectArray = new List<T>();
        internal int _id = 0;
        public Switcher(List<T> list)
        {
            ObjectArray = list;
        }
        public Switcher()
        {
            SetActive(0);
        }
        public void SetActive(int id) { _id = id; }
        public int AtiveID { get { return _id; } private set { } }
        public T GetActiveObject() { return ObjectArray[_id]; }
        public T SwitchLeft()
        {
            _id--;
            _id = (_id < 0) ? ObjectArray.Count - 1 : _id;
            return ObjectArray[_id];
        }
        public T SwitchRight()
        {
            _id++;
            _id = (_id == ObjectArray.Count) ? 0 : _id;
            return ObjectArray[_id];
        }

    }
}
