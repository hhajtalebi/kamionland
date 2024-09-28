using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class ApplicationMeasages
    {
        public const string DuplicatedRecord = "رکورد تکراری وجود دارد. لطفا بررسی نمائید";
        public const string RecordNotFound = "هیچ رکوردی پیدا نشد لطفا مجددا سعی نمائید";
        public static string PasswordsNotMatch = "پسورد و تکرار آن با هم مطابقت ندارند";
        public static string WrongUserPass = "نام کاربری یا کلمه رمز اشتباه است";

        public static string SuccessPay = "پرداخت با موفقیت انجام شد";
        public static string NotSuccessPay = "پرداخت با شکست مواجه شد";

        public static string OfflineSuccess = "  سفارش شما به صورت کارت به کارت ثبت شد لطفا تا تماس کارشناس پشتیبانی منتظر بمانید ";

        public static int OnlinePaymentMethod = 1;
        public static int OfflinePaymentMethod = 2;
        public static int CreditPymentMethod=3;

        public static string RegisterOrlogin = "لطفا ابتدا ثبت نام کنید و یا اینکه وارد سیستم شوید";
        public static string lonin = "ورود با موفقیت انجام شد";
        public static string Notlonin = "ورود با شکست موجه شد";
        public static string Crash = "عملیات باشکست مواجه شد";
        public static string Success="عملیات با موفقیت انجام شد ";
        public static string securityCodeNotFound="کد وارد شده صحیح نمی باشد";

    }
}
