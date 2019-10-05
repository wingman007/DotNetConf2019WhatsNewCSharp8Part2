using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019C8Part2
{ // deadly diamond
    interface ILogger
    {
        void Log(string message);
    }

    //class ConsoleLogger : ILogger
    //{
    //    void ILogger.Log(string msg) => Console.WriteLine(msg);
    //}

    //class DatabaseLogger : ILogger
    //{
    //    void ILogger.Log(string msg) => Console.WriteLine($"'{msg}' inserted in DB");
    //}

    interface IConsoleLogger : ILogger
    {
        void ILogger.Log(string msg) => Console.WriteLine(msg);
    }
    class ConsoleLogger : IConsoleLogger { }

    interface IDatabaseLogger : ILogger
    {
        void ILogger.Log(string msg) => Console.WriteLine($"'{msg}' inserted in DB");
    }
    class DatabaseLogger : IDatabaseLogger { }

    // class DatabaseLogger : IDatabaseLogger, IConsoleLogger{ } // You can not do this bouth have implementation 

    // ... some other loggers
    enum LoggerType { Console, Database, /* etc.*/}
    static class LoggerFactory
    {
        public static ILogger GetLogger(LoggerType ltype) => ltype switch
        { 
            LoggerType.Console => new ConsoleLogger(),
            LoggerType.Database => new DatabaseLogger(),
            _ => throw new Exception("Logger doesn't exist")
        };
    } 
    class DefaultInterfaceMembers
    {
        public static void Demo()
        {
            var lc = LoggerFactory.GetLogger(LoggerType.Console);
            lc.Log("Hello");
            var ld = LoggerFactory.GetLogger(LoggerType.Database);
            ld.Log("Hello");
        }
    }
}
