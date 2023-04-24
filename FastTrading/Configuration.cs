﻿using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace FastTrading {
  [Serializable]
  public class Configuration : IPluginConfiguration {
    public int Version { get; set; } = 0;

    public bool Testing { get; set; } = true;

    [NonSerialized]
    private DalamudPluginInterface? PluginInterface;

    public void Initialize(DalamudPluginInterface pluginInterface) {
      PluginInterface = pluginInterface;
    }

    public void Save() {
      PluginInterface!.SavePluginConfig(this);
    }
  }
}
