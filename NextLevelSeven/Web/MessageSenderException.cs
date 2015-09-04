﻿using System;
using NextLevelSeven.Diagnostics;

namespace NextLevelSeven.Web
{
    /// <summary>
    ///     Represents an exception that would be thrown by a web HL7 message sender.
    /// </summary>
    [Serializable]
    public class MessageSenderException : MessageTransportException
    {
        /// <summary>
        ///     Create a generic message sender exception.
        /// </summary>
        public MessageSenderException(ErrorCode code) : base(code)
        {
        }
    }
}