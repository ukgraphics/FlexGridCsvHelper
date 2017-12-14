using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FlexGridCsv
{
    public class PostalCodeModel
    {
        public String ID { get; set; }      // ID
        public String ZIP { get; set; }    // 郵便番号の上3桁
        public String Postal7 { get; set; }  // 7桁の郵便番号
        public String Pref { get; set; }   // 都道府県
        public String City { get; set; }   // 市区町村
        public String Town { get; set; }   // 地番

        public PostalCodeModel()
        {
        }

        public static List<PostalCodeModel> getPostalCodeList()
        {
            var _postalCodeList = new List<PostalCodeModel>();  //リストを作成

            var assembly = typeof(PostalCodeModel).GetTypeInfo().Assembly;
            //データファイルからデータを読み込み
            Stream stream = assembly.GetManifestResourceStream("FlexGridCsv.04MIYAGI.CSV");

            // Before (Xuni)
            //using (var sr = new System.IO.StreamReader(stream))

            // After (C1Xamarin)
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //using (var sr = new StreamReader(stream, Encoding.GetEncoding("shift-jis")))
            //{
            //    int count = 1;
            //    while (!sr.EndOfStream)
            //    {
            //        //1行ずつ読み込む
            //        var sn = sr.ReadLine().Split(',');
            //        if (sn.Length > 1 && sn[0].Trim().Length > 0)
            //        {
            //            var data = new PostalCodeModel();
            //            data.ID = sn[0].ToString();
            //            //郵便番号データを格納
            //            data.ZIP = sn[1].ToString();
            //            // 数値データを郵便番号形式にフォーマット
            //            //data.Postal7 = String.Format("{0:000-0000}", int.Parse(sn[2].ToString()));
            //            data.Postal7 = sn[2].ToString();
            //            data.Pref = sn[6].ToString();
            //            data.City = sn[7].ToString();
            //            data.Town = sn[8].ToString();
            //            _postalCodeList.Add(data); //データをリストに追加
            //            count++;
            //        }
            //    }
            //}

            // After (C1Xamarin)
            // Use CsvHelper
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var csvReader = new CsvReader(new StreamReader(stream, Encoding.GetEncoding("shift-jis"))))
            {
                while (csvReader.Read())
                {
                    var data = new PostalCodeModel();

                    data.ID = csvReader.GetField<string>(0).ToString();
                    //郵便番号データを格納
                    data.ZIP = csvReader.GetField<string>(1).ToString();
                    // 数値データを郵便番号形式にフォーマット
                    data.Postal7 = String.Format("{0:000-0000}", int.Parse(csvReader.GetField<string>(2).ToString()));
                    //data.Postal7 = csvReader.GetField<string>(2).ToString();
                    data.Pref = csvReader.GetField<string>(6).ToString();
                    data.City = csvReader.GetField<string>(7).ToString();
                    data.Town = csvReader.GetField<string>(8).ToString();

                    _postalCodeList.Add(data); //データをリストに追加
                }
            }
            return _postalCodeList;
        }
    }
}
