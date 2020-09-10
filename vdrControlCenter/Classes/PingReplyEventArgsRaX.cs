namespace vdrControlCenterUI.Classes
{
    using System;
    using System.Collections.Generic;

    public class PingReplyEventArgsRaX : EventArgs
    {
        public int Found { get; set; }
        public PingReplyRaX Reply
        {
            get
            {
                return ReplyList.Count == 1 ? ReplyList[0] : null;
            }
        }

        public List<PingReplyRaX> ReplyList { get; set; }

        public TimeSpan Elapsed { get; set; }

        public object Cargo { get; set; }

        public PingReplyEventArgsRaX()
        {
            Found = 0;
            ReplyList = new List<PingReplyRaX>();
            Elapsed = new TimeSpan();
        }
    }
}
