//-----------------------------------------------------------------------
// <copyright file="FtpResponse.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;

using JetBrains.Annotations;

namespace FubarDev.FtpServer
{
    /// <summary>
    /// FTP response
    /// </summary>
    public class FtpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FtpResponse"/> class.
        /// </summary>
        /// <param name="code">The response code</param>
        /// <param name="message">The response message</param>
        /// <param name="multiLine">Will there be another response message coming after this?</param>
        public FtpResponse(int code, [CanBeNull] string message, bool multiLine = false)
        {
            Code = code;
            Message = message;
            MultiLine = multiLine;
        }

        /// <summary>
        /// Gets the response code
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Gets the response message
        /// </summary>
        [CanBeNull]
        public string Message { get; }

        /// <summary>
        /// Gets or sets the <see cref="Action"/> to execute after sending the response to the client.
        /// </summary>
        public Action AfterWriteAction { get; set; }

        /// <summary>
        /// Gets a value indicating whether a dash or a space will be used in the response
        /// </summary>
        public bool MultiLine { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Code:D3}{(MultiLine ? "-" : " ")}{Message}".TrimEnd();
        }
    }
}
