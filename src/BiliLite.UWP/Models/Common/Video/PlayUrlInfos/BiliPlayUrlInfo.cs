﻿using System.Collections.Generic;

namespace BiliLite.Models.Common.Video.PlayUrlInfos
{
    public class BiliPlayUrlInfo
    {
        /// <summary>
        /// 是否包含有播放链接
        /// </summary>
        public bool HasPlayUrl { get; set; }
        /// <summary>
        /// 清晰度ID
        /// </summary>
        public int QualityID { get; set; }
        /// <summary>
        /// 清晰度名称
        /// </summary>
        public string QualityName { get; set; }
        /// <summary>
        /// 播放链接的类型
        /// </summary>
        public BiliPlayUrlType PlayUrlType { get; set; }
        /// <summary>
        /// HTTP请求头-UserAgent
        /// </summary>
        public string UserAgent { get; set; } = "";
        /// <summary>
        /// HTTP请求头-Referer
        /// </summary>
        public string Referer { get; set; } = "https://www.bilibili.com/";
        /// <summary>
        /// 视频编码
        /// </summary>
        public BiliPlayUrlVideoCodec Codec { get; set; } = BiliPlayUrlVideoCodec.AVC;
        /// <summary>
        /// 时长，毫秒
        /// </summary>
        public long Timelength { get; set; }
        /// <summary>
        /// DASH播放信息
        /// </summary>
        public BiliDashPlayUrlInfo DashInfo { get; set; }
        /// <summary>
        /// FLV信息
        /// </summary>
        public List<BiliFlvPlayUrlInfo> FlvInfo { get; set; }
        public IDictionary<string, string> GetHttpHeader()
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (UserAgent != null && UserAgent.Length > 0)
            {
                headers.Add("User-Agent", UserAgent);
            }
            if (Referer != null && Referer.Length > 0)
            {
                headers.Add("Referer", Referer);
            }
            return headers;
        }
    }
}
