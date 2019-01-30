using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegate
{
          public class Publisher
          {
                    //Declare Delegate
                    public delegate void PublishMessageDel(string msg);

                    //Declare an instance variable which is a Delegate object 
                    public PublishMessageDel publishmsg = null;

                    //Method used to Invoke Delegate
                    public void PublishMessage(string message)
                    {
                              //Invoke Delegate
                              publishmsg.Invoke(message);
                    }
          }
}
