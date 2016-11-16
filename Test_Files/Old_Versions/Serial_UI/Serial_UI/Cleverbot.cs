using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cleverbot.Net;
using Serial_UI;

namespace Serial_UI
{
    class Cleverbot
    {
        private const string apiUser = "JtI8RiDyrluMva5p";
        private const string apiKey = "Tw24THomFgg7EGJgKdqNcdArMViCykan";

        public static CleverbotSession createSession()
        {
            var session = CleverbotSession.NewSession(apiUser, apiKey);
            return session;
        }

        public static string getChatResponse(CleverbotSession session, string message)
        {
            string response = session.Send(message);
            return response;
        }
    }
}
