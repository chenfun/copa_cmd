using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaCmd.ViewModel.Sensor
{
    public class SensorValueResponse
    {
        /// <summary>API取得的資料類型</summary>
        public string apiType { get; set; }

        /// <summary>API版本</summary>
        public string apiVersion { get; set; }

        public Dictionary<string, SensorItemData> data { get; set; }

        /// <summary>當地時間(UTC+8)</summary>
        public DateTime localTime { get; set; }

        /// <summary>API回傳的error code，除錯用(預設：00正常)</summary>
        public string responseCode { get; set; }

        /// <summary>API回傳訊息(成功會回傳success)</summary>
        public string responseMsg { get; set; }

        /// <summary>API回覆時間(UTC+0)</summary>
        public DateTime responseTime { get; set; }

        /// <summary>機上盒的設定名稱</summary>
        public string thingAlias { get; set; }

        /// <summary>機上盒id</summary>
        public string thingName { get; set; }
    }

    public class SensorItemData
    {
        /// <summary>感測器id</summary>
        public string id { get; set; }

        /// <summary>感測器狀態(0：感測器斷線、1：連線正常、2：警報異常)</summary>
        public int status { get; set; }

        /// <summary>資料更新時間(UTC+0)</summary>
        public DateTime updateTime { get; set; }

        /// <summary>感測器數值</summary>
        public Dictionary<string, object> values { get; set; }
    }
}