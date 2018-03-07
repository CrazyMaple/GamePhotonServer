using Photon.SocketServer;
using Common;
using Common.Tools;

namespace GamePhotonServer.Handler
{
    public class SyncPositionHandler : BaseHandler
    {
        public SyncPositionHandler()
        {
            OpCode = OperationCode.SyncPosition;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            string strX = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.X).ToString();
            string strY = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Y).ToString();
            string strZ = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.Z).ToString();

            GameServer.log.Info("Coordinate:(" + strX + "," + strY + "," + strZ + ")");
        }
    }
}
