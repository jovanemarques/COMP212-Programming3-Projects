using System;

namespace MulticastDelegate
{
    class Driver
    {
        public static void Main(string[] args)
        {
            Publisher publisher = new Publisher();

            SendViaMobile send2Mobile = new SendViaMobile("416 1234567");

            SendViaMobile send2Mobile2 = new SendViaMobile("416 1239999");

            SendViaMobile send2Mobile3 = new SendViaMobile("647 123 4567");

            SendViaEmail send2Email = new SendViaEmail("yli@my.centennialcollege.ca");

            SendViaEmail send3Email = new SendViaEmail("jdearau1@my.centennialcollege.ca");

            SendViaEmail sub2 = new SendViaEmail("yli202@my.centennialcollege.ca");

            //Subscribing for Mobile notifications
            sub2.Subscribe(publisher);
            send2Mobile.Subscribe(publisher);

            send2Mobile2.Subscribe(publisher);

            send2Mobile3.Subscribe(publisher);

            send3Email.Subscribe(publisher);

            //Emails are not subscribed so it wont receive notifications via Email
            send2Email.Subscribe(publisher);

            //Invoking the delegate Only Mobile will receive notifications.
            publisher.PublishMessage("Hello You Have New Notifications");

            Console.WriteLine();

            send2Mobile3.UnSubscribe(publisher);
            send2Email.UnSubscribe(publisher);
            publisher.PublishMessage("Hello You Have More New Notifications");

            Console.ReadKey();
        }
    }
}
