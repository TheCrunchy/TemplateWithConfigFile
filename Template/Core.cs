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
        private void SetupConfig()
        {
            FileUtils utils = new FileUtils();

            if (File.Exists(StoragePath + "\\TemplateConfig.xml"))
            {
                config = utils.ReadFromXmlFile<Config>(StoragePath + "\\TemplateConfig.xml");
                utils.WriteToXmlFile<Config>(StoragePath + "\\TemplateConfig.xml", config, false);
            }
            else
            {
                config = new Config();
                utils.WriteToXmlFile<Config>(StoragePath + "\\TemplateConfig.xml", config, false);
            }

        }
        private void SessionChanged(ITorchSession session, TorchSessionState newState)
        {

        }
        public static Config config;


    }
}

