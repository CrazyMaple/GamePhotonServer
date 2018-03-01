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

            GameServer.log.Info("Request Code :" + operationRequest.OperationCode + " UserName:" + strUserName + " Password:" + strPassWord);
            IUserManager userManager = new UserManager();
            bool bLoginSucess = userManager.VerifyUser(strUserName, strPassWord);
            GameServer.log.Info("Login Sucess:" + bLoginSucess);

            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add((byte)ParameterCode.LoginState, bLoginSucess);
            OperationResponse opResponse = new OperationResponse((byte)OperationCode.Login, data);
            peer.SendOperationResponse(opResponse, sendParameters);
        }
    }
}
