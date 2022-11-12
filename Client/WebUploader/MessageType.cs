using System;
using System.Collections.Generic;
using System.Text;

namespace WebUploader
{
    internal enum MessageType
    {
        Continuos = 0,
        Text,
        Binary,
        Close,
        Ping,
        Pong
    }
}
