using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace UdpKoi
{
	static class Program
	{
		static void Main()
		{
			string ipad = File.ReadAllText(@"Data/ip.txt");
			UdpClient koi = new UdpClient();
		
			byte[] bmsg = Encoding.UTF8.GetBytes(File.ReadAllText(@"Data/data.txt"));

			koi.Send(bmsg, bmsg.Length, ipad, 8888);
			Console.WriteLine("{0} 로 {1} 바이트 전송", ipad, bmsg.Length);
			Console.WriteLine ("DATA : {0}", File.ReadAllText(@"Data/data.txt"));
			koi.Close();
		}
	}
}