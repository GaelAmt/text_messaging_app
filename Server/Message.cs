using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [Serializable]
    public class Message : ISerializable
    {
        public string Msg { set; get; }

        public Message(string m)
        {
            Msg = m;
        }

        public Message(SerializationInfo info, StreamingContext context)
        {
            Msg = (string)info.GetValue("message", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("message", Msg);
        }
    }
}
