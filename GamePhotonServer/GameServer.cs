using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using System.IO;
using log4net.Config;

using Common;
using Photon.SocketServer;
using GamePhotonServer.Handler;
using GamePhotonServer.Manager;
using System.Collections.Generic;

namespace GamePhotonServer
{
    public class GameServer : ApplicationBase
    {
        public new static GameServer Instance
        {
            get;
            private set;
        }

        public Dictionary<OperationCode, BaseHandler> HandlerDict = new Dictionary<OperationCode, BaseHandler>();

        public static readonly ILogger log = LogManager.GetCurrentClassLogger();

        //当一个客户端请求链接的
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            log.Info("一个客户端连接进来了");
            return new ClientPeer(initRequest);
        }

        //初始化
        protected override void Setup()
        {
            Instance = this;

            // 日志的初始化
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(
                                                                    Path.Combine(this.ApplicationRootPath, "bin_Win64"), "log");
            FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if (configFileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);//让photon知道
                XmlConfigurator.ConfigureAndWatch(configFileInfo);//让log4net这个插件读取配置文件
            }

            log.Info("Setup Completed！");

            //IUserManager userManager = new UserManager();
            //log.Info(userManager.VerifyUser("wer", "wer"));
            //log.Info(userManager.VerifyUser("wer2", "wer"));

            InitHandlers();
        }

        void InitHandlers()
        {
            LoginHandler loginHandler = new LoginHandler();
            HandlerDict.Add(loginHandler.OpCode, loginHandler);
            DefaultHandler defaultHandler = new DefaultHandler();
            HandlerDict.Add(defaultHandler.OpCode, defaultHandler);
        }

        //server端关闭的时候
        protected override void TearDown()
        {
        }
    }
}
