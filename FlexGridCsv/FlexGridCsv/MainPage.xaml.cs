using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlexGridCsv
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            var postalcodevm = new PostalCodeViewModel();
            grid.ItemsSource = postalcodevm.PostalCodeList;

            // 先頭の2列は非表示
            grid.Columns[0].IsVisible = false;
            grid.Columns[1].IsVisible = false;
            // FlexGridに表示する列のヘッダーを指定
            grid.Columns[2].Header = "郵便番号";
            grid.Columns[3].Header = "都道府県";
            grid.Columns[4].Header = "市区町村";
            grid.Columns[5].Header = "地番";
            // 列幅を比率で指定するスターサイズ機能
            grid.Columns[2].Width = new GridLength(1, GridUnitType.Star);
            grid.Columns[3].Width = new GridLength(1.5, GridUnitType.Star);
            grid.Columns[4].Width = new GridLength(1.5, GridUnitType.Star);
            grid.Columns[5].Width = new GridLength(2, GridUnitType.Star);

            // 列ヘッダーのみを表示する
            grid.HeadersVisibility = C1.Xamarin.Forms.Grid.GridHeadersVisibility.Column;
        }
	}
}
