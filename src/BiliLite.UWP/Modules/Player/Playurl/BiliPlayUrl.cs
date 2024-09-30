using BiliLite.Models.Common.Video;
using BiliLite.Models.Common.Video.PlayUrlInfos;
using System.Threading.Tasks;
using BiliLite.Services;

namespace BiliLite.Modules.Player.Playurl
{

    public class BiliPlayUrl
    {
        public bool IsDownload { get; set; } = false;
        public BiliPlayUrl(bool isDownload)
        {
            IsDownload = isDownload;
        }

        public async Task<BiliPlayUrlQualitesInfo> GetPlayUrl(PlayInfo playInfo, int qualityID, int soundQualityId = 0)
        {
            BiliPlayUrlRequest request;
            if (playInfo.play_mode == VideoPlayType.Season)
            {
                request = new BiliSeasonPlayUrlRequest(IsDownload);
            }
            else
            {
                request = new BiliVideoPlayUrlRequest(IsDownload);
            }

            if (SettingService.GetValue<bool>(SettingConstants.Player.DISABLE_VIDEO_STREAM, false))
            {
                qualityID = 0; // Set qualityID to 0 to disable video stream
            }

            return await request.GetPlayUrlInfo(playInfo, qualityID, soundQualityId);
        }

    }
  
    

}
