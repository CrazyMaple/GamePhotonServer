using Photon.SocketServer;
using Common;
using Common.Tools;
using GamePhotonServer.Manager;
using GamePhotonServer.Model;

namespace GamePhotonServer.Handler
{
    public class RegisterHandler : BaseHandler
    {
        public RegisterHandler()
        {
            OpCode = OperationCode.Register;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            string strUserName = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.UserName).ToString();
            string strPassWord = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.PassWord).ToString();

            IUserManager userManager = new UserManager();
            ReturnCode returnCode = userManager.Add(new User(strUserName, strPassWord)) ? ReturnCode.Success : ReturnCode.Failed;

            OperationResponse opResponse = new OperationResponse(operationRequest.OperationCode);
            opResponse.ReturnCode = (short)returnCode;
            peer.SendOperationResponse(opResponse, sendParameters);
        }
    }
}
