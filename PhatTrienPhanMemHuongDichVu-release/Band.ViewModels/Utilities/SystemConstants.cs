using System;
using System.Collections.Generic;
using System.Text;

namespace Band.ViewModels.Utilities
{
    public class SystemConstants
    {
        public const string BankAccount="123451234512345";
        public enum ActionType
        {
            CREATE,
            READ,
            UPDATE,
            UPDATE_POSITION,
            DELETE,
        }
        public enum ImageType
        {
            AVATAR_MEM=1,
            COVER_MEM=2,
            IMG_SHOW=3,
            IMG_BAND=4,
            LOGO=5
        }

        public enum BookingErrorCode
        {
            SOLD_OUT=-5,
            BOOKED=-4,
            OFF_HOURS=-6
        }

        public enum BankErrorCode
        {
            LOGIN_FAILED = -3,
            INCORRECT_DES_ACC=-2,
            BALANCE_NOT_ENOUGH=-1

        }
    }
}
