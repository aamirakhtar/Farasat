using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Farasat
{
    class VideoEncoder
    {
        //public void Encode(Video video)
        //{
        //    mailService.Send(new System.Net.Mail()); //we are sending mail after video encode
        //    //lets say in future we want to have text msg after video encode and watsapp msg also
        //    // so we will add following extra lines
        //    textMsgService.Send(new TextMessage());
        //    watsappMsgService.Send(new WatsappMessage());

        //    //so that means on each addition of subscription of msg service we need to compile the code and redeploy it
        //    //also all the dependent classes on it will be redeployed which can be several projects
        //}

        /// <summary>
        /// So we want a publisher subscriber model so that any number of subscribers can be added to that without changing the publisher which
        /// will be like this
        /// </summary>
        /// <param name="video"></param>
        //public void Encode(Video video)
        //{
        //    //Encoding Logic
        //    //......

        //    OnVideoEncoded();// the purpose of this method is to simly notify the subscribers whether it be one or many services subscribed to it
        //}

        /// <summary>
        /// As its loosely coupled publisher knows nothing about the subscriber so how it will call the 
        /// sibsciber's function to send notification... here comes the agreement b/w publisher and subscriber
        /// we call it as delegates.. its a pointer to function of certain signature to which any subscriber's method will be
        /// attached and publisher will only call that pointer which indirectly call the subscriber's function.
        /// </summary>
        /// <param name="video"></param>

        /// <summary>
        ///lets have simple implimentation of Encode
        /// </summary>
        //public void Encode(Video video)
        //{
        //    Console.WriteLine("Encoding video...");
        //    Thread.Sleep(2000);
        //}

        /// <summary>
        /// Now we want videoencoder to notify all the subscribers at the end of encoding
        /// 1-Define Delegate (agreement b/w publisher and subscriber)
        /// 2-Define Event based on that delegate
        /// 3-Raise Event
        /// </summary>

        //Point 1- Define Delegate we have c# convention of parameters in event handlers
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);

        //Point 2-Define Event using based on that delegate
        public event VideoEncodedEventHandler VideoEncoded;

        //Point 3-Raise Event. To raise an event we need to create a function which is responsible to raise that event
        //Dot Net suggests that your event publisher method should be protected virtual void and start with "On" and name of the event "VideoEncoded"
        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);// the source is VideoEncoder which is the source who is responsible to raise the event
        }

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(2000);
            Console.WriteLine("Encoding done...");

            OnVideoEncoded();
        }
    }

    //public class EntryPointEvents
    //{
    //    public static void Main()
    //    {
    //        var video = new Video() { Title = "New Video" };
    //        var videoEncoder = new VideoEncoder();

    //        videoEncoder.Encode(video);
    //    }
    //}

    public class Video
    {
        public string Title { get; set; }
    }

    //Lets make subscribers
    public class MailService
    {
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("Sending an Email...");
        }
    }

    //And now our Main will be like
    public class EntryPointEvents
    {
        public static void eventsMain()
        {
            var video = new Video() { Title = "New Video" };
            var videoEncoder = new VideoEncoder();//publisher

            var mailService = new MailService();//subscriber
            var textService = new TextService();//subscriber
            var watsappService = new WatsappService();//subscriber

            //videoEncoder.VideoEncoded is nothing but a collection of subscribers which can be attached to it
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //Subscribing to event
            videoEncoder.VideoEncoded += textService.OnVideoEncoded; //Subscribing to event
            videoEncoder.VideoEncoded += watsappService.OnVideoEncoded; //Subscribing to event

            videoEncoder.Encode(video);

            Console.ReadLine();
        }
    }

    //Lets make another subscriber
    public class TextService
    {
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("Sending a Text Message...");
        }
    }

    //Lets make another subscriber
    public class WatsappService
    {
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("Sending a Watsapp Message...");
        }
    }

    //Note: You see we dot suppose to change the publisher and re-deploy it we just add subscribers and deploy them without changing
    //a single line on publisher

    //Now EventArgs are the parent of all eventAgs we should make VideoEventArgs
    public class VideoEventArgs : EventArgs
    {
        public Video video { get; set; }
    }
    //And we will change Event Args with this and change accordingly

    //Also line #: 63 is not needed rather we can use EventHandler<VideoEventArgs> VideoEncoded instead of VideoEncodedEventHandler on line 65
}
