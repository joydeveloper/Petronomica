using System;
using System.Reflection;

namespace ElementX
{
    /// <summary>
    /// For all classes. 
    /// </summary>
    public abstract class BaseX
    {
        protected string _name;
        public string TName{get{return GetType().Name; }
            set
            {
                if ((value != string.Empty))
                {
                    _name = value;
                }
                else
                {
                    _name = "Unnamed:" + GetType().Name;
                }
            }
        }
        public virtual string ShowProperties()
        {
            FieldInfo[] fi = GetType().GetFields();
            string _proplist = null; 
            foreach (FieldInfo f in fi)
            {
                _proplist+=f.Name + f.GetValue(this);
            }
            return _proplist;
        }
    }
}
