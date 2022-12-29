using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMovieTicket
{
    public interface IWallet
    {
        public double WalletBalance {get; }
        public void RechargeWallet(int amount)
        {}
    }
}