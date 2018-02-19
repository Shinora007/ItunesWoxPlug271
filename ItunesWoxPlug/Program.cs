using System.Collections.Generic;
using iTunesLib;
using Wox.Plugin;

namespace ItunesWoxPlug
{
    public class Program : IPlugin
    {
        private IiTunes _itApp;

        public static void Main(string[] args)
        {
            var _itApp = new iTunesApp();
            try
            {
                var songList = _itApp.LibraryPlaylist.Search("Unravel", ITPlaylistSearchField.ITPlaylistSearchFieldSongNames);

                if (songList.Count > 0)
                {
                    var track = songList.ItemByPlayOrder[1];
                    track.Play();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Init(PluginInitContext context)
        {
            _itApp = new iTunesApp();
        }

        public List<Result> Query(Query query)
        {
            List<Result> results = new List<Result>();
            results.Add(new Result()
            {
                Title = "Jai howe",
                SubTitle = "Sub title",
                IcoPath = "Images\\plugin.png",  //relative path to your plugin directory
                Action = e =>
                {
                    // after user select the item

                    // return false to tell Wox don't hide query window, otherwise Wox will hide it automatically
                    return false;
                }
            });
            return results;
        }
    }
}
