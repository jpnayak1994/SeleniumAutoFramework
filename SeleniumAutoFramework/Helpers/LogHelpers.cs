using SeleniumAutoFramework.Config;
using System;
using System.IO;
using System.Threading;


namespace SeleniumAutoFramework.Helpers
{
    public class LogHelpers
    {
        //Global Declaration
        private static string _logFileName = String.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private  StreamWriter _streamw = null;
        private static int count = 1;
        private static Object myLock = new Object();
        private static Object myLock1 = new Object();
        //Create a file which can store the log information
        public StreamWriter CreateLogFile(string TestName)
        {
            lock (myLock)
            {
                string dir = Settings.Config_LogPath; //@"D:\SeleniumCodeUdemy\LogFiles\";
                string fullpath = dir;
                //if(TestName.Equals("TestLogin"))
                //{
                //    fullpath = fullpath + "TestLogin\\";
                //}
                //else if (TestName.Equals("Testemployee"))
                //{
                //    fullpath = fullpath + "Testemployee\\";
                //}
                //else if (TestName.Equals("LoginSpecFlow"))
                //{
                //    fullpath = fullpath + "LoginFeature\\";
                //}
                //else if (TestName.Equals("LoginSpecFlow"))
                //{
                //    fullpath = fullpath + "EmployeeFeature\\";
                //}
                if (Directory.Exists(dir))
                {
                    //try
                    //{
                    if (File.Exists(fullpath + TestName + _logFileName + ".log"))
                    {
                        _streamw = File.AppendText(fullpath + TestName + _logFileName + "_" + count + ".log");
                        count = count + 1;
                    }
                    else
                    {
                        _streamw = File.AppendText(fullpath + TestName + _logFileName + ".log");
                    }



                }
                else
                {
                    Directory.CreateDirectory(fullpath);
                    _streamw = File.AppendText(fullpath + TestName + _logFileName + ".log");
                }
            }
            return _streamw;
        }
        public static void  LogFile(string TestName, string LogMessage)
        {
            lock (myLock)
            {
                StreamWriter _streamw = null;
                string dir = Settings.Config_LogPath;
                string fullpath = dir;          
                if (Directory.Exists(dir))
                {
                    
                    if (File.Exists(fullpath + TestName + _logFileName + ".log"))
                    {
                        
                            using (_streamw = new StreamWriter(fullpath + TestName + _logFileName + ".log", true))
                            {
                            _streamw.Write("{0}  {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                            _streamw.WriteLine("    {0}", LogMessage);
                            //_streamw.WriteLine(LogMessage);
                        }

                    }
                    else
                    {
                        _streamw = File.AppendText(fullpath + TestName + _logFileName + ".log");
                        _streamw.Write("{0}  {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                        _streamw.WriteLine("    {0}", LogMessage);
                        //_streamw.WriteLine(LogMessage);
                    }



                }
                else
                {
                    Directory.CreateDirectory(fullpath);
                    _streamw = File.AppendText(fullpath + TestName + _logFileName + ".log");
                    _streamw.Write("{0}  {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                    _streamw.WriteLine("    {0}", LogMessage);
                    //_streamw.WriteLine(LogMessage);
                }
                _streamw.Dispose();
            }
           
        }
        //Create a method which can create the text in the text file
        public  void Write(string LogMessage,StreamWriter _streamwriter)
        {
            lock (myLock1)
            {
                _streamwriter.Write("{0}  {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                _streamwriter.WriteLine("    {0}", LogMessage);
                _streamwriter.Flush();
            }

        }
    }
}
