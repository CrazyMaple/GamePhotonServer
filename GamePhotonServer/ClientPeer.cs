﻿using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace GamePhotonServer
{
    enum RequestCode
    {
        Test = 0
    };

    public class ClientPeer : Photon.SocketServer.ClientPeer
    {
        public ClientPeer(InitRequest initRequest)
            : base(initRequest)
        {
        }

        //处理客户端断开链接的后续工作
        protected override void OnDisconnect(DisconnectReason disconnectCode, string reasonDetail)
        {
        }

        //处理客户端的请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            switch ((RequestCode)operationRequest.OperationCode)//要是code不在枚举范围内呢？应该用const int?
            {
                case RequestCode.Test:
                    {
                        GameServer.log.Info("接收到数据：" + operationRequest.Parameters[1]);
                        OperationResponse opResponse = new OperationResponse((int)RequestCode.Test, operationRequest.Parameters);
                        SendOperationResponse(opResponse, sendParameters);//该方法仅能在该函数中调用

                        EventData eData = new EventData(1, operationRequest.Parameters);
                        SendEvent(eData, new SendParameters());//可以在该类中任意地方调用，服务端主动通知客户端
                    }
                    break;
                default: break;
            }
        }
    }
}