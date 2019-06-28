using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carne.Pages
{

    public class OwnerPageMenuItem
    {
        public OwnerPageMenuItem()
        {
            TargetType = typeof(OwnerPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageAddress { get; set; }
        public Type TargetType { get; set; }
    }
}