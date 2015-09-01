using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace ServiceWebSoket.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        //这里是单独建立一个控制器来建立连接测试
        //public ActionResult  Conenction()
        //{
        //    if (HttpContext.IsWebSocketRequest)
        //    {
        //        HttpContext.AcceptWebSocketRequest(ProcessWSChat);
        //    }
        //    return Content("");
        //}

        //private async Task ProcessWSChat(AspNetWebSocketContext arg)
        //{
        //    WebSocket socket = arg.WebSocket;
        //    while (true)
        //    {
        //        ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
        //        WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);
        //        if (socket.State == WebSocketState.Open)
        //        {
        //            string message = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
        //            string returnMessage = "You send :" + message + ". at" + DateTime.Now.ToLongTimeString();
        //            buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(returnMessage));
        //            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //}

    }
}
