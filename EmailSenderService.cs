using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace K180239_Q1
{
    public class EmailSenderService
    {
        private readonly Timer __timer;

        public EmailSenderService()
        {
            __timer = new Timer(9000) {AutoReset = true}; 
            __timer.Elapsed +=  TimerEvent;
        }

        private void TimerEvent(object sender ,ElapsedEventArgs e)
        {
            //Read Data From Json
           Email email = ReadDataFromJson();

           //Send An Email 
            email.SendMail();

        }

        private Email ReadDataFromJson()
        {
            StreamReader r = new StreamReader(@"/home/daniyal/Desktop/K180239_Q1/Data.json");
            string jsonString = r.ReadToEnd();
            Email m = JsonConvert.DeserializeObject<Email>(jsonString);
            return m;
        }

        public void Start()
        {
            __timer.Start();
        }
        public void Stop()
        {
            __timer.Stop();
        }
    }

}