using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [Serializable]
    public class User : ISerializable
    {
        public string login
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }

        public User(SerializationInfo info, StreamingContext ctxt)
        {
            login = (string)info.GetValue("login", typeof(string));
            password = (string)info.GetValue("password", typeof(string));
        }

        public User(string l, string p)
        {
            login = l;
            password = p;
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("login", login);
            info.AddValue("password", password);
        }

        public override string ToString()
        {
            return "User :" + login + ", " + password;
        }
    }

    [Serializable]
    public class UserLogin : User
    {
        public UserLogin(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
        {
        }

        public UserLogin(string l, string p) : base(l, p)
        {
        }

    }

    [Serializable]
    public class UserRegister : User
    {
        public UserRegister(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
        {
        }

        public UserRegister(string l, string p) : base(l, p)
        {
        }
    }

    [Serializable]
    public class UserDisconnect : User
    {
        public UserDisconnect(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
        {
        }

        public UserDisconnect(string l, string p) : base(l, p)
        {
        }
    }
}
