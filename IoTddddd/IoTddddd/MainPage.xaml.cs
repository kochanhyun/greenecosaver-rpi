using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Networking.Sockets;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IoTddddd
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public class senser
    {
        static public string uvs, temps, humbs, ;

        void main()
        {
            uvs = "text";
        }
    }

    class udps
    {

        public async void setting()
        {
            Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();

            socket.MessageReceived += Socket_MessageReceived;

            string serverPort = "8888";

            //Bind the socket to the serverPort so that we can start listening for UDP messages from the UDP echo client.
            //Socket.BindServiceNameAsync(serverPort);

            await socket.BindServiceNameAsync(serverPort);
        }

        private async void Socket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender, Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
        {
            char message;
            message = Convert.ToChar(senser.uvs);


            //Create a new socket to send the same message back to the UDP echo client.
            Windows.Networking.Sockets.DatagramSocket socket = new Windows.Networking.Sockets.DatagramSocket();

            //Use a separate port number for the UDP echo client because both will be unning on the same machine.
            string clientPort = "8888";
            Stream streamOut = (await socket.GetOutputStreamAsync(args.RemoteAddress, clientPort)).AsStreamForWrite();
            StreamWriter writer = new StreamWriter(streamOut);
            await writer.WriteLineAsync(message);
            await writer.FlushAsync();
        }
    }


    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}
