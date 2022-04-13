using System;
using System.Threading.Tasks;
using System.Windows;

namespace DemoTaskWpf
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }
    private async void buttonStart_Click(object sender, RoutedEventArgs e)
    {
      // griser/dégriser les buttons
      // faire bouger la progress bar
      progressBar1.IsIndeterminate = true;
      buttonCancel.IsEnabled = true;
      buttonStart.IsEnabled = false;

      // Simulation de l'appel à un serveur
      // Pas bien : bloque le thread graphique
      //Thread.Sleep(TimeSpan.FromSeconds(3));

      Task t = Task.Delay(TimeSpan.FromSeconds(3));
      // Pas bien : bloque le thread graphique
      //t.Wait();
      // Bien car bloque l'instruction suivante mais pas le thread graphique
      await t;
      // restaurer l'état des boutons et la progress bar
      progressBar1.IsIndeterminate = false;
      buttonCancel.IsEnabled = false;
      buttonStart.IsEnabled = true;
    }
  }
}
