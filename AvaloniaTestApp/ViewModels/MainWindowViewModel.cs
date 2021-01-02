using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace AvaloniaTestApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        public ObservableCollection<TreeNode> TreeNodes { get; set; }

        public ReactiveCommand<Unit, Unit> RemoveRootNodeCommand { get; set; }

        public ReactiveCommand<Unit, Unit> ReloadCommand { get; set; }

        public MainWindowViewModel()
        {
            RemoveRootNodeCommand = ReactiveCommand.CreateFromTask(RemoveRootNode);
            ReloadCommand = ReactiveCommand.CreateFromTask(Reload);
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(500);
                var mainNodes = new ObservableCollection<TreeNode>();
                mainNodes = CreateNodes(null, 10, 5);
                TreeNodes = mainNodes;
                RaisePropertyChangedEvent(nameof(TreeNodes));
            });
        }

        private async Task Reload()
        {
            ProgressWindow.Start();
            //await Task.Run(() =>
            //{
            //    var mainNodes = new ObservableCollection<TreeNode>();
            //    mainNodes = CreateNodes(null, 10, 5);
            //    TreeNodes = mainNodes;
            //    RaisePropertyChangedEvent(nameof(TreeNodes));
            //});
        }

        private ObservableCollection<TreeNode> CreateNodes(ObservableCollection<TreeNode> nodes, int count, int depth)
        {
            if (nodes == null)
            {
                var mainNodes = new ObservableCollection<TreeNode>();
                for (int i = 0; i < 50; i++)
                {
                    var subNodes = new ObservableCollection<TreeNode>();
                    if (depth > 1) 
                    {
                        CreateNodes(subNodes, count, depth - 1);
                    }
                    
                    var mainNode = new TreeNode
                    {
                        DisplayName = "RootNode " + i,
                        SizeDisplayValue = "100 MB",
                        IsRootNode = true,
                        Nodes = subNodes
                    };
                    mainNodes.Add(mainNode);
                }

                return mainNodes;
            }
            else
            {
                if (depth > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var subNode = new TreeNode { DisplayName = "SubItem" + i, Nodes = new ObservableCollection<TreeNode>() };
                        CreateNodes(subNode.Nodes, count, depth - 1);
                        nodes.Add(subNode);
                    }

                }
                return null;
            }
        }

        public async Task RemoveRootNode()
        {
            await Task.Run(() => Trace.WriteLine("test"));
        }
    }
}
