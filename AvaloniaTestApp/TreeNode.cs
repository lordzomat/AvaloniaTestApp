using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AvaloniaTestApp
{
    public class TreeNode
    {
        public bool IsRootNode { get; set; }

        public string DisplayName { get; set; }

        public string SizeDisplayValue { get; set; }

        public ObservableCollection<TreeNode> Nodes { get; set; }
    }
}
