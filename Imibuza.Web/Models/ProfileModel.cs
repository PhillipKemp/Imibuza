using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Imibuza.Domain;

namespace Imibuza.Web.Models
{
    public class ProfileModel
    {
        public static ProfileModel FromDomain(Profile profile)
        {
            return new ProfileModel
            {
                Weaknesses = profile.Weaknesses.Select(ResultModel.FromDomain).ToList(),
                Strengths = profile.Strengths.Select(ResultModel.FromDomain).ToList(),
            };
        }

        public List<ResultModel> Strengths { get; set; }

        public List<ResultModel> Weaknesses { get; set; }
    }
}