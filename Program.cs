using System;
using System.Runtime.InteropServices;
using K180239_Q1;
using Topshelf;
using Topshelf.Runtime.DotNetCore;

namespace HearBeat
{
    class Program
    {
        static void Main(string[] args)

        {
            var is_windows = false;
            var exitcode = HostFactory.Run(x =>
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ||RuntimeInformation.IsOSPlatform(OSPlatform.Linux) )
                {
                    x.UseEnvironmentBuilder(
                      target => new DotNetCoreEnvironmentBuilder(target)
                    );
                    is_windows = false;
                }
                else
                {
                    is_windows = true;
                }
                x.Service<EmailSenderService>(s =>
                {
                    s.ConstructUsing(email => new EmailSenderService());
                    s.WhenStarted(email => email.Start());
                    s.WhenStopped(email => email.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("EmailSenderService");
                x.SetDisplayName("Email Sender Service ");
                x.SetDescription("This is the simple Email sneding service");
            });
            if(is_windows==true)
            {
                int exitCodeValue = (int)Convert.ChangeType(exitcode , exitcode.GetTypeCode());
                Environment.ExitCode = exitCodeValue;
            }
            
        }
    }
}
