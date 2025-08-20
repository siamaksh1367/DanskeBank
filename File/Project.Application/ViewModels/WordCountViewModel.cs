using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.ViewModels
{
    public partial class WordCountViewModel:ObservableObject
    {
        [ObservableProperty]
        private int _count;
        [ObservableProperty]
        private string _word;
    }
}
