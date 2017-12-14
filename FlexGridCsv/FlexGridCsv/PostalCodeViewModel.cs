using System;
using System.Collections.Generic;
using System.Text;

namespace FlexGridCsv
{
    public class PostalCodeViewModel
    {
        public PostalCodeViewModel()
        {
        }

        // データセットを返すプロパティ-FlexGridのItemsSourceに接続
        public List<PostalCodeModel> PostalCodeList
        {
            // データモデルから郵便番号リストを取得
            get { return PostalCodeModel.getPostalCodeList(); }
        }
    }
}
