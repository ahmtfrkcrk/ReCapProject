﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string Added = "Eklendi";
        public static string InvalidName = "İsmi en az 2 karakterden oluşmalı";
        public static string MaintenanceTime = "Bakım arası";
        public static string Listed = "Listelendi";
        public static string DailyRentalFee = "Günlük kiralama ücreti 0 veya 0 'dan az bir tutar olamaz";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string VehicleNotFound = "Kiralanacak araç bulunamadı";
        public static string AutomaticIncrementField = "Otomatik artan alan değer girilemez";
        public static string AuthorizationDenied= "Yetki reddedildi";
        public static string UserRegistered = "Başarıyla kullanıcı oluşturuldu";
        public static string UserNotFound ="Kullanıcı bulunamadı";
        public static string PasswordError="Geçersiz parola";
        public static string UserAlreadyExists="Bu kullanıcı mevcut";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string AccessTokenCreated="Token oluşturuldu";
    }
}
