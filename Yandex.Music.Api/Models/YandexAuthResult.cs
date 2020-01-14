using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Yandex.Music.Api.Models
{
    public class YandexAuthResult
    {
        public string Csrf { get; set; }
        public string FreshCsrf { get; set; }
        public string Uid { get; set; }
        public string Login { get; set; }
        public string YandexuId { get; set; }
        public bool Logged { get; set; }
        public bool Premium { get; set; }
        public string Lang { get; set; }
        public long Timestamp { get; set; }
        public string Experements { get; set; }
        public bool BadRegion { get; set; }
        public bool NotFree { get; set; }
        public string DeviceId { get; set; }
        
    }
    
    public class YandexExperements
    {
        public Dictionary<string, string> Fields { get; set; }

        public YandexExperements(JToken json)
        {
            Fields = new Dictionary<string, string>();
            
            foreach (var field in json)
            {
                Console.WriteLine("123");
            }
        }

        public string ToSource()
        {
            var result = "";
            
            foreach (var keyValuePair in Fields)
            {
                var fieldName = keyValuePair.Key;
                var fieldValue = keyValuePair.Value;

//                result += $"\"{fieldName}\":{}";
            }

            return $"{{{result}}}";
        }
        
        public string boostConfigExperiment5dfc94111f183806f3373f4f { get; set; }
        public string boostConfigExperiment5df479fe293df5523e0a2e86 { get; set; }
        public string webSimilarArtistsInHead { get; set; }
        public string webAntiMusicBlockNaGlavnoi { get; set; }
        public string musicCheckPass { get; set; }
        public string musicYellowButton { get; set; }
        public string musicVideoOnArtistPage { get; set; }
        public string musicUzbekistanLang { get; set; }
        public string BlockOrderByRelevanceWeb { get; set; }
        public string musicKazakhstanLang { get; set; }
        public string webBughunter { get; set; }
        public string searchPrioritizeOwnContent { get; set; }
        public string musicPrice { get; set; }
        public string ugcPrivat { get; set; }
        public string searchDoNotRemoveStopwords { get; set; }
        public string musicCryMeARiver { get; set; }
        public string musicLoginWallElapse { get; set; }
        public string boostConfigExperiment5dc5a44a8ab61649c7f0a115 { get; set; }
        public string webNewPlaylistsTabHide { get; set; }
        public string branchLinks { get; set; }
        public string windowsEqualizer { get; set; }
        public string musicTouchNewPleer { get; set; }
        public string webMusicPreroll { get; set; }
        public string ugc { get; set; }
        public string musicHighlightLyrics { get; set; }
        public string miniBrick { get; set; }
        public string musicCspLogger { get; set; }
        public string musicgift { get; set; }
        public string musicErrorLogger { get; set; }
        public string musicCrackdownContent { get; set; }
        public string musicLoginWall { get; set; }
        public string musicArtistDetailInfo { get; set; }
        public string webAutoPlaylistAnimated { get; set; }
        public string boostConfigExperiment5df47980293df5523e0a2e68 { get; set; }
        public string userFeed { get; set; }
        public string musicYellowButtonAuth { get; set; }
        public string music30SecToMars { get; set; }
        public string musicStatsLogger { get; set; }
        public string boostConfigExperiment5df47997293df5523e0a2e6f { get; set; }
        public string plusWeb { get; set; }
        public string musicCollectivePlaylist { get; set; }
        public string searchPrioritizeLikes { get; set; }
        public string musicNewGenres { get; set; }
        public string musicSuggest { get; set; }
        public string boostConfigExperiment5dea42390060757a86beb5cd { get; set; }
        public string SubStation { get; set; }
        public string webAntiMusicTab { get; set; }
        public string musicSearchFormula { get; set; }
        public string rotorIosHappyNewYearDesign { get; set; }
        public string boostConfigExperiment5dc5a3ef8ab61649c7f0a105 { get; set; }
        public string musicTestDebugProducts { get; set; }
        public string boostConfigExperiment5e037188d189cd0705a818f5 { get; set; }
        public string boostConfigExperiment5cb9e0aa7cfafa58d9db3914 { get; set; }
        public string musicCrackdownPopup { get; set; }
        public string musicTakeEMail { get; set; }
        public string djvuCandidates { get; set; }
        public string musicArtistStat { get; set; }
        public string webPPbanners { get; set; }
        public string musicSyncQueue { get; set; }
        public string webPlaylistOfTheDayCounter { get; set; }
        public string musicAutoFlow { get; set; }
        public string musicMobileWebLocked { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
//        public string  { get; set; }
    }
}