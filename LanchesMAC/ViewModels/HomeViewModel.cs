using LanchesMAC.Models;
using System.Collections.Generic;

namespace LanchesMAC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}
