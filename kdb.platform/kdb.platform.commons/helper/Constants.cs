using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kdb.platform.commons.helper
{
    public sealed class Constants
    {
        public const string CHARSET_UTF8 = "utf-8";

        public const string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string DATE_TIME_MS_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";

        public const string SIGN_METHOD_MD5 = "md5";
        public const string SIGN_METHOD_HMAC = "hmac";

        public const string LOG_SPLIT = "^_^";
        public const string LOG_FILE_NAME = "topsdk.log";

        public const string ACCEPT_ENCODING = "Accept-Encoding";
        public const string CONTENT_ENCODING = "Content-Encoding";
        public const string CONTENT_ENCODING_GZIP = "gzip";

        public const string ERROR_RESPONSE = "error_response";
        public const string ERROR_CODE = "code";
        public const string ERROR_MSG = "msg";

        public const string QIMEN_CLOUD_ERROR_RESPONSE = "response";
        public const string QIMEN_CLOUD_ERROR_CODE = "code";
        public const string QIMEN_CLOUD_ERROR_MSG = "message";

        public const string SDK_VERSION = "top-sdk-net-20170525";
        public const string SDK_VERSION_CLUSTER = "top-sdk-net-cluster-20170525";

        public const string APP_KEY = "app_key";
        public const string FORMAT = "format";
        public const string METHOD = "method";
        public const string TIMESTAMP = "timestamp";
        public const string VERSION = "v";
        public const string SIGN = "sign";
        public const string SIGN_METHOD = "sign_method";
        public const string PARTNER_ID = "partner_id";
        public const string SESSION = "session";
        public const string FORMAT_XML = "xml";
        public const string FORMAT_JSON = "json";
        public const string SIMPLIFY = "simplify";
        public const string TARGET_APP_KEY = "target_app_key";

        public const string QM_ROOT_TAG_REQ = "request";
        public const string QM_ROOT_TAG_RSP = "response";
        public const string QM_CUSTOMER_ID = "customerId";
        public const string QM_CONTENT_TYPE = "text/xml;charset=utf-8";
        public const string QM_TARGETAPPKEY = "targetAppkey";

        public const string CTYPE_DEFAULT = "application/octet-stream";
        public const string CTYPE_FORM_DATA = "application/x-www-form-urlencoded";
        public const string CTYPE_FILE_UPLOAD = "multipart/form-data";
        public const string CTYPE_TEXT_XML = "text/xml";
        public const string CTYPE_TEXT_PLAIN = "text/plain";
        public const string CTYPE_APP_JSON = "application/json";
        public const int READ_BUFFER_SIZE = 1024 * 4;

        public const string SMS_TYPE = "sms_type";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public const string EXTEND = "extend";//{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        public const string REC_NUM = "rec_num";//{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        public const string SMS_FREE_SIGN_NAME = "sms_free_sign_name";// { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public const string SMS_PARAM = "sms_param";// { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public const string SMS_TEMPLATE_CODE = "sms_template_code";//{ get; set; }

    }
}
