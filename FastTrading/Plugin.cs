using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using FastTrading.Windows;

namespace FastTrading {
  public sealed class Plugin : IDalamudPlugin {
    public string Name => "FastTrading";
    private const string CommandName = "/fasttrading";

    public Configuration Configuration { get; init; }
    public WindowSystem WindowSystem = new("FastTrading");

    private MainWindow MainWindow { get; init; }

    [PluginService]
    internal static DalamudPluginInterface PluginInterface { get; private set; } = null!;
    [PluginService]
    internal static CommandManager CommandManager { get; private set; } = null!;

    public Plugin() {
      Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
      Configuration.Initialize(PluginInterface);

      MainWindow = new MainWindow();

      WindowSystem.AddWindow(MainWindow);

      CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand) {
        HelpMessage = "A useful message to display in /xlhelp"
      });

      PluginInterface.UiBuilder.Draw += DrawUI;
    }

    public void Dispose() {
      WindowSystem.RemoveAllWindows();
      MainWindow.Dispose();
      CommandManager.RemoveHandler(CommandName);
    }

    private void OnCommand(string command, string args) {
      MainWindow.IsOpen = true;
    }

    private void DrawUI() {
      WindowSystem.Draw();
    }
  }
}
