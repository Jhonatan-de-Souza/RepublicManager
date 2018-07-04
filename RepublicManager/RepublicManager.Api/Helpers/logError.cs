﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpRaven;
using SharpRaven.Data;

namespace RepublicManager.Api.Helpers
{
    public static class logError
    {
        public static void LogErrorWithSentry(Exception exception)
        {
            var ravenClient = new RavenClient("https://9aa7031c98df48d8a95f09e1905f573d@sentry.io/1236656");
            ravenClient.Capture(new SentryEvent(exception));
        }
    }
}