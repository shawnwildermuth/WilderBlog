﻿using System;
using Microsoft.Extensions.Logging;
using WilderBlog.Services;

namespace WilderBlog.Logger
{
  public class EmailLogger : ILogger
  {
    private string _categoryName;
    private Func<string, LogLevel, bool> _filter;
    private IMailService _mailService;

    public EmailLogger(string categoryName, Func<string, LogLevel, bool> filter, IMailService mailService)
    {
      _categoryName = categoryName;
      _filter = filter;
      _mailService = mailService;
    }

    public IDisposable BeginScopeImpl(object state)
    {
      // Not necessary
      return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
      return (_filter == null || _filter(_categoryName, logLevel));
    }

    public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    {
      if (!IsEnabled(logLevel))
      {
        return;
      }

      if (formatter == null)
      {
        throw new ArgumentNullException(nameof(formatter));
      }

      var message = formatter(state, exception);

      if (string.IsNullOrEmpty(message))
      {
        return;
      }

      message = $@"Level: {logLevel}

{message}";

      if (exception != null)
      {
        message += Environment.NewLine + Environment.NewLine + exception.ToString();
      }

      _mailService.SendMail("logmessage.txt", "Shawn Wildermuth", "shawn@wildermuth.com", "[WilderBlog Log Message]", message);

    }
  }
}