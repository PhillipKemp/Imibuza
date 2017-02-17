using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Imibuza.Domain;

namespace Imibuza.Web.Models
{
    public class ResultModel
    {
        public static ResultModel FromDomain(Result result)
        {
            return new ResultModel
            {
                Category = result.Category,
                Value = result.Value,
                Percentage = result.Percentage
            };
        }

        public decimal Percentage { get; set; }

        public string Value { get; set; }

        public string Category { get; set; }
    }
}