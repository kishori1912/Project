using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipes.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}