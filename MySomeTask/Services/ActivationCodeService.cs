using System;

namespace MySomeTask.Services
{
    public class ActivationCodeService : IActivationCodeService
    {
        public int GetNew()
        {
            var r = new Random(DateTime.Now.Second);
            return r.Next(10000, 99999);         
        }
    }
}
