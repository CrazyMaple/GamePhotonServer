using Common;
using Photon.SocketServer;
using GamePhotonServer;

using Common.Tools;
using GamePhotonServer.Manager;
using System.Collections.Generic;

namespace GamePhotonServer.Handler
{
    public class LoginHandler : BaseHandler
    {
        public LoginHandler()
        {
            OpCode = OperationCode.Login;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            
            string strUserName = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.UserName).ToString();
            string strPassWord = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)ParameterCode.PassWord).ToString();

            IUserManager userManager = new UserManager();
            ReturnCode returnCode = userManager.VerifyUser(strUserName, strPassWord) ? ReturnCode.Success : ReturnCode.Failed;
            if (returnCode == ReturnCode.Success)//储存用户名
            {
                peer.UserName = strUserName;
            }

            //Dictionary<byte, object> data = new Dictionary<byte, object>();
            //data.Add((byte)returnCode, returnCode);
            //OperationResponse opResponse = new OperationResponse((byte)OperationCode.Login, data);

            OperationResponse opResponse = new OperationResponse(operationRequest.OperationCode);
            opResponse.ReturnCode = (short)returnCode;
            peer.SendOperationResponse(opResponse, sendParameters);
        }
    }
}
