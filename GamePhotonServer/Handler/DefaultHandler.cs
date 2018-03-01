using System;
using Common;
using Photon.SocketServer;

namespace GamePhotonServer.Handler
{
    public class DefaultHandler : BaseHandler
    {
        public DefaultHandler()
        {
            OpCode = OperationCode.Default;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            throw new System.NotImplementedException();
        }
    }
}
