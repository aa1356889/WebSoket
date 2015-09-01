using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace WebSocketSample.Controllers
{
    public class WSChatController : ApiController
    {
        /// <summary>
        /// 页面那边发送连接请求会到这里
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            //验证是否是websoket请求
            if (HttpContext.Current.IsWebSocketRequest)
            {
                //这一步应该是客户端像服务端推送数据的处理函数 保存到委托里面
                HttpContext.Current.AcceptWebSocketRequest(ProcessWSChat);
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        private async Task ProcessWSChat(AspNetWebSocketContext context)
        {
            //拿到他们通信的套接字 可以接收和推送信息
            WebSocket socket = context.WebSocket;
            while (true)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                //取得客户端推送的信息
                WebSocketReceiveResult result = await socket.ReceiveAsync(
                    buffer, CancellationToken.None);
                if (socket.State == WebSocketState.Open)
                {
                    string userMessage = Encoding.UTF8.GetString(
                        buffer.Array, 0, result.Count);
                    userMessage = "You sent: " + userMessage + " at " +
                        DateTime.Now.ToLongTimeString();
                    buffer = new ArraySegment<byte>(
                        Encoding.UTF8.GetBytes(userMessage));
                    //向客户端推送信息
                    await socket.SendAsync(
                        buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    break;
                }
            }
        }
    } 
}