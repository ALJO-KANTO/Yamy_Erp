using System;
using System.Collections;
using System.Text;

public static class AmountToWordsHelper
{
    #region PUBLIC METHODS

    public static string ConvertToEnglish(decimal amount, string mainCurrency, string subCurrency)
    {
        long integerPart = (long)Math.Floor(amount);
        int fractionPart = (int)Math.Round((amount - integerPart) * 100, 0);

        string words = "";

        if (integerPart == 0)
            words = "Zero";
        else
            words = NumberToEnglish(integerPart);

        words += " " + (integerPart == 1 ? mainCurrency : mainCurrency + "s");

        if (fractionPart > 0)
        {
            words += " and " + NumberToEnglish(fractionPart) + " " + (fractionPart == 1 ? subCurrency : subCurrency);
        }

        words += " Only";
        return words;
    }

    public static string ConvertToArabic(decimal amount, string mainCurrency, string subCurrency)
    {
        long integerPart = (long)Math.Floor(amount);
        int fractionPart = (int)Math.Round((amount - integerPart) * 100, 0);

        string words = "";

        if (integerPart == 0)
            words = "صفر";
        else
            words = NumberToArabic(integerPart);

        words += " " + GetArabicCurrencyName(integerPart, mainCurrency);

        if (fractionPart > 0)
        {
            words += " و" + NumberToArabic(fractionPart) + " " + GetArabicCurrencyName(fractionPart, subCurrency);
        }

        words += " فقط لا غير";
        return words;
    }

    #endregion

    #region ENGLISH

    private static string NumberToEnglish(long number)
    {
        if (number == 0)
            return "Zero";

        if (number < 0)
            return "Minus " + NumberToEnglish(Math.Abs(number));

        string words = "";

        if ((number / 1000000000) > 0)
        {
            words += NumberToEnglish(number / 1000000000) + " Billion ";
            number %= 1000000000;
        }

        if ((number / 1000000) > 0)
        {
            words += NumberToEnglish(number / 1000000) + " Million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += NumberToEnglish(number / 1000) + " Thousand ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += NumberToEnglish(number / 100) + " Hundred ";
            number %= 100;
        }

        if (number > 0)
        {
            if (words != "")
                words += "and ";

            string[] unitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                                  "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                                  "Eighteen", "Nineteen" };

            string[] tensMap = { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
        }

        return words.Trim();
    }

    #endregion

    #region ARABIC

    private static string NumberToArabic(long number)
    {
        if (number == 0)
            return "صفر";

        if (number < 0)
            return "سالب " + NumberToArabic(Math.Abs(number));

        return ConvertArabic(number).Trim();
    }

    private static string ConvertArabic(long number)
    {
        string[] ones =
        {
            "", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة",
            "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر",
            "ستة عشر", "سبعة عشر", "ثمانية عشر", "تسعة عشر"
        };

        string[] tens =
        {
            "", "", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون"
        };

        string[] hundreds =
        {
            "", "مائة", "مائتان", "ثلاثمائة", "أربعمائة", "خمسمائة",
            "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة"
        };

        if (number < 20)
            return ones[number];

        if (number < 100)
        {
            if (number % 10 == 0)
                return tens[number / 10];
            return ones[number % 10] + " و" + tens[number / 10];
        }

        if (number < 1000)
        {
            if (number % 100 == 0)
                return hundreds[number / 100];
            return hundreds[number / 100] + " و" + ConvertArabic(number % 100);
        }

        if (number < 1000000)
        {
            long thousands = number / 1000;
            long remainder = number % 1000;

            string thousandsText = "";

            if (thousands == 1)
                thousandsText = "ألف";
            else if (thousands == 2)
                thousandsText = "ألفان";
            else if (thousands >= 3 && thousands <= 10)
                thousandsText = ConvertArabic(thousands) + " آلاف";
            else
                thousandsText = ConvertArabic(thousands) + " ألف";

            if (remainder == 0)
                return thousandsText;

            return thousandsText + " و" + ConvertArabic(remainder);
        }

        if (number < 1000000000)
        {
            long millions = number / 1000000;
            long remainder = number % 1000000;

            string millionsText = "";

            if (millions == 1)
                millionsText = "مليون";
            else if (millions == 2)
                millionsText = "مليونان";
            else if (millions >= 3 && millions <= 10)
                millionsText = ConvertArabic(millions) + " ملايين";
            else
                millionsText = ConvertArabic(millions) + " مليون";

            if (remainder == 0)
                return millionsText;

            return millionsText + " و" + ConvertArabic(remainder);
        }

        long billions = number / 1000000000;
        long billionsRemainder = number % 1000000000;

        string billionsText = "";

        if (billions == 1)
            billionsText = "مليار";
        else if (billions == 2)
            billionsText = "ملياران";
        else if (billions >= 3 && billions <= 10)
            billionsText = ConvertArabic(billions) + " مليارات";
        else
            billionsText = ConvertArabic(billions) + " مليار";

        if (billionsRemainder == 0)
            return billionsText;

        return billionsText + " و" + ConvertArabic(billionsRemainder);
    }

    private static string GetArabicCurrencyName(long number, string baseCurrency)
    {
        // Simple practical version for ERP usage
        // You can customize per currency if you want exact grammar.
        if (baseCurrency == "درهم")
        {
            if (number == 1) return "درهم";
            if (number == 2) return "درهمان";
            if (number >= 3 && number <= 10) return "دراهم";
            return "درهماً";
        }

        if (baseCurrency == "فلس")
        {
            if (number == 1) return "فلس";
            if (number == 2) return "فلسان";
            if (number >= 3 && number <= 10) return "فلوس";
            return "فلساً";
        }

        return baseCurrency;
    }

    public static string ConvertToSelectedLanguage(decimal value) //,bool isCurrency, string baseCurrency)
    {
        string savedCulture = YamyProject.Properties.Settings.Default.ApplicationLanguage ?? "en";

        switch (savedCulture)
        {
            case "en":
                return ConvertToEnglish(value, "Dirham", "Fils");
            case "ar":
                return ConvertToArabic(value, "درهم", "فلس");
            case "fr":
                return ConvertToEnglish(value, "Euro", "Centime");
            case "hi":
                return ConvertToEnglish(value, "Rupees", "Paisa");
            case "ur":
                return ConvertToEnglish(value, "Rupees", "Paisa");
            case "es":
                return ConvertToEnglish(value, "Euro", "Céntimo");
            case "gr":
                return ConvertToEnglish(value, "Euro", "Cent");
            case "ja":
                return ConvertToEnglish(value, "Yen", "Sen");
            case "ko":
                return ConvertToEnglish(value, "Won", "Jeon");
            case "fil":
                return ConvertToEnglish(value, "Piso", "Sentimo");
            case "zh-CN":
                return ConvertToEnglish(value, "Yuan", "Fen");
            case "zh-TW":
                return ConvertToEnglish(value, "Yuan", "Fen");
            default:
                return ConvertToEnglish(value, "", "");

        }
    }

    #endregion
}