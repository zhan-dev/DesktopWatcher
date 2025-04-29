using System;
using System.IO;
using System.Windows.Forms;

namespace DesktopWatcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            history_lbl.Text = $"Desktop history: {Environment.NewLine}";
            FileSystemWatcher watcher = new FileSystemWatcher(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
            { EnableRaisingEvents = true, SynchronizingObject = this };

            watcher.Created += Watcher_Created;
            watcher.Renamed += Watcher_Renamed;
            watcher.Changed += Watcher_Changed;
            watcher.Deleted += Watcher_Deleted;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e) => history_lbl.Text += 
            $@"Юзер {Environment.UserDomainName} ({Environment.UserName}) создал '{e.Name}' | {DateTime.Now}{Environment.NewLine}";

        private void Watcher_Renamed(object sender, RenamedEventArgs e) => history_lbl.Text +=
            $"Юзер {Environment.UserDomainName} ({Environment.UserName}) переименовал '{e.OldName}' в '{e.Name}' | {DateTime.Now}{Environment.NewLine}";

        private void Watcher_Changed(object sender, FileSystemEventArgs e) => history_lbl.Text +=
            $"Юзер {Environment.UserDomainName} ({Environment.UserName}) изменил '{e.Name}' | {DateTime.Now}{Environment.NewLine}";

        private void Watcher_Deleted(object sender, FileSystemEventArgs e) => history_lbl.Text +=
            $"Юзер {Environment.UserDomainName} ({Environment.UserName}) удалил '{e.Name}' | {DateTime.Now}{Environment.NewLine}";
    }
}
