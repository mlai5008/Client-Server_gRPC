using System;

namespace Education.Domain.EventArguments
{
    public class ClientConnectedEventArgs : EventArgs
    {
        #region Properties
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Ip { get; set; }
        #endregion
    }
}