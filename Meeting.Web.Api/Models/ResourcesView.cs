using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meeting.Web.Api.Models
{
    public class ResourcesView
    {
        public List<mMeetingResources> Text;

        public List<mMeetingResources> Vide;

        public TitleViewModel TitleModel { get; set; }
    }
}