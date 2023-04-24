using Dalamud.Interface.Windowing;
using ImGuiNET;
using System;
using System.Numerics;

namespace FastTrading.Windows;

public class MainWindow : Window, IDisposable {
  public MainWindow() : base("FastTrading", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse) {
    SizeConstraints = new WindowSizeConstraints {
      MinimumSize = new Vector2(375, 330),
      MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
    };
  }

  public void Dispose() {
    GC.SuppressFinalize(this);
  }

  public override void Draw() {
    ImGui.Text("Yo");
  }
}
