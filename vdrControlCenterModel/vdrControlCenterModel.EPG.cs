﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 26.09.2020 08:19:49
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace vdrControlCenterModel
{
    public partial class EPG {

        public EPG()
        {
            OnCreated();
        }

        public virtual long RecId { get; set; }

        public virtual DateTime? Modtime { get; set; }

        public virtual long? ChannelRecId { get; set; }

        public virtual int? EventID { get; set; }

        public virtual DateTime? StartTime { get; set; }

        public virtual int? Duration { get; set; }

        public virtual string TableID { get; set; }

        public virtual string Version { get; set; }

        public virtual string Title { get; set; }

        public virtual string ShortDescription { get; set; }

        public virtual string Description { get; set; }

        public virtual string GenreCodes { get; set; }

        public virtual int? ParentalRating { get; set; }

        public virtual string Stream { get; set; }

        public virtual DateTime? VPS { get; set; }

        public virtual Channel Channel { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
