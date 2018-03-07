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
            float fX = (float)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.X);
            float fY = (float)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.X);
            float fZ = (float)DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.X);
            peer.Position = new Vector3Data(fX, fY, fZ);

            string strX = fX.ToString();
            string strY = fY.ToString();
            string strZ = fZ.ToString();

            GameServer.log.Info("Coordinate:(" + strX + "," + strY + "," + strZ + ")");
        }
    }
}
