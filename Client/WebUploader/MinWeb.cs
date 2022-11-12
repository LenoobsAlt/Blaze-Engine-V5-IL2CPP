using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace WebUploader
{
    public static class MinWeb
    {
        /// <param name="message">Message if type != true or File src if type == true</param>
        /// <param name="type">null is Send | true is send file | false is send html</param>
        public static void Send(this NetworkStream stream, string message, bool? type = null)
        {
            if (type == null)
            {
                stream.Send(message);
            }
            else if (type == true)
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    byte[] fileBytes = File.ReadAllBytes(message);
                    sw.Write("HTTP/1.0 200 OK\r\n\r\n");
                    sw.Flush(); //  <-- HERE
                    sw.BaseStream.Write(fileBytes, 0, fileBytes.Length);
                    sw.Close();
                }
            }
            else
            {
                byte[] byteMsg = Encoding.UTF8.GetBytes(message);
                string szBuffer = "HTTP/1.1 200 OK\r\n";
                szBuffer += "Connection: close\r\n";
                szBuffer += "Content-Length: " + byteMsg.Length + "\r\n";
                szBuffer += "Content-type: application/json; charset=utf-8\r\n";
                szBuffer += "Access-Control-Allow-Headers: Origin, X-Requested-With, Content-Type, Accept, Terminal-Type\r\n";
                szBuffer += "Access-Control-Allow-Origin: *\r\n";
                szBuffer += "Access-Control-Allow-Credentials: true\r\n";
                szBuffer += "\r\n" + message;

                stream.Send(szBuffer);
            }
        }

        public static void Send(this NetworkStream stream, string message)
        {
            byte[] byteMsg = Encoding.UTF8.GetBytes(message);
            stream.Send(byteMsg);
        }

        public static void Send(this NetworkStream stream, byte[] message)
        {
            stream.Write(message, 0, message.Length);
        }

        internal static byte[] CreateFrame(string message, MessageType messageType = MessageType.Text, bool messageContinues = false)
        {
            byte b1 = 0;
            byte b2 = 0;

            switch (messageType)
            {
                case MessageType.Continuos:
                    b1 = 0;
                    break;
                case MessageType.Text:
                    b1 = 1;
                    break;
                case MessageType.Binary:
                    b1 = 2;
                    break;
                case MessageType.Close:
                    b1 = 8;
                    break;
                case MessageType.Ping:
                    b1 = 9;
                    break;
                case MessageType.Pong:
                    b1 = 10;
                    break;
            }

            b1 = (byte)(b1 + 128); // set FIN bit to 1

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            if (messageBytes.Length < 126)
            {
                b2 = (byte)messageBytes.Length;
            }
            else
            {
                if (messageBytes.Length < Math.Pow(2, 16) - 1)
                {
                    b2 = 126;

                }
                else
                {
                    b2 = 127;
                }

            }

            byte[] frame = null;

            if (b2 < 126)
            {
                frame = new byte[messageBytes.Length + 2];
                frame[0] = b1;
                frame[1] = b2;
                Array.Copy(messageBytes, 0, frame, 2, messageBytes.Length);
            }
            if (b2 == 126)
            {
                frame = new byte[messageBytes.Length + 4];
                frame[0] = b1;
                frame[1] = b2;
                byte[] lenght = BitConverter.GetBytes(messageBytes.Length);
                frame[2] = lenght[1];
                frame[3] = lenght[0];
                Array.Copy(messageBytes, 0, frame, 4, messageBytes.Length);
            }

            if (b2 == 127)
            {
                frame = new byte[messageBytes.Length + 10];
                frame[0] = b1;
                frame[1] = b2;
                byte[] lenght = BitConverter.GetBytes((long)messageBytes.Length);

                for (int i = 7, j = 2; i >= 0; i--, j++)
                {
                    frame[j] = lenght[i];
                }
            }

            return frame;
        }
    }
}
