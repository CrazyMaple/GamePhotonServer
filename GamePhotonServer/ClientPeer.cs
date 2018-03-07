using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using Common;
using Common.Tools;
using GamePhotonServer;
using GamePhotonServer.Handler;

namespace GamePhotonServer
{
    public class ClientPeer : Photon.SocketServer.ClientPeer
    {
        public string UserName = "";
        public Vector3Data Position = new Vector3Data();
        public ClientPeer(InitRequest initRequest)
            : base(initRequest)
        {
        }

        //处理客户端断开链接的后续工作
        protected override void OnDisconnect(DisconnectReason disconnectCode, string reasonDetail)
        {
            GameServer.Instance.peerList.Remove(this);
        }

        //处理客户端的请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            BaseHandler handler = DictTool.GetValue<OperationCode, BaseHandler>(GameServer.Instance.HandlerDict, (OperationCode)operationRequest.OperationCode);
            if (handler != null)
            {
                handler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            else
            {
                BaseHandler defaultHandler = DictTool.GetValue<OperationCode, BaseHandler>(GameServer.Instance.HandlerDict, OperationCode.Default);
                defaultHandler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            //switch ((RequestCode)operationRequest.OperationCode)//要是code不在枚举范围内呢？应该用const int?
            //{
            //    case RequestCode.Test:
            //        {
            //            GameServer.log.Info("接收到数据：" + operationRequest.Parameters[1]);
            //            OperationResponse opResponse = new OperationResponse((int)RequestCode.Test, operationRequest.Parameters);
            //            SendOperationResponse(opResponse, sendParameters);//该方法仅能在该函数中调用

            //            EventData eData = new EventData(1, operationRequest.Parameters);
            //            SendEvent(eData, new SendParameters());//可以在该类中任意地方调用，服务端主动通知客户端
            //        }
            //        break;
            //    default: break;
            //}
        }
    }
}
