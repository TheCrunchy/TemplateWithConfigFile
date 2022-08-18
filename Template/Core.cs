using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torch;
using Torch.API;
using Torch.API.Plugins;
using Torch.Managers;
using Torch.API.Managers;
using Torch.Session;
using Torch.API.Session;
using Torch.Managers.PatchManager;
using System.Reflection;
using Sandbox.Game.Entities.Cube;
using System.IO;
using Sandbox.Game.GameSystems;

namespace Template
{
    public class Core : TorchPluginBase
    {
        public static Config config;
        public int ticks;
        public TorchSessionState TorchState;
        public override void Init(ITorchBase torch)
        {
            base.Init(torch);

            var sessionManager = Torch.Managers.GetManager<TorchSessionManager>();

            if (sessionManager != null)
            {
                sessionManager.SessionStateChanged += SessionChanged;
            }

            SetupConfig();

        }
        
        public override void Update()
        {
            //here you can do stuff in the games update, this will run once every 256 ticks so, lower is more frequent, higher is less frequent
            ticks++;
            if (ticks % 256 == 0 && TorchState == TorchSessionState.Loaded)
            {
                
            }
        }

        private void SetupConfig()
        {
            FileUtils utils = new FileUtils();
            //to make your own folder, just put it in the path
            //example folder StoragePath + "\\Example\\TemplateConfig.xml"
            var path = StoragePath + "\\TemplateConfig.xml";
            Directory.CreateDirectory(path);
            if (File.Exists(path))
            {
                config = utils.ReadFromXmlFile<Config>(path);
                utils.WriteToXmlFile<Config>(path, config, false);
            }
            else
            {
                config = new Config();
                utils.WriteToXmlFile<Config>(path, config, false);
            }

        }

        private void SessionChanged(ITorchSession session, TorchSessionState newState)
        {
            TorchState = newState;
            if (newState is TorchSessionState.Loaded)
            {
                //example stuff
            }
        }
    }
}

