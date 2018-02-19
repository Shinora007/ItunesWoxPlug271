using System.Collections.Generic;
using iTunesLib;
using Wox.Plugin;

namespace ItunesWoxPlug
{
    public class Program
    {
        private IiTunes _itApp;

        public static void Main(string[] args)
        {
            var _itApp = new iTunesApp();
            try
            {
                var songList = _itApp.LibraryPlaylist.Search("rain", ITPlaylistSearchField.ITPlaylistSearchFieldSongNames);

                if (songList != null)
                {
                    //var track = songList.ItemByPlayOrder[1];
                    //track.Play();
                    for(int i=1; i<=songList.Count; i++)
                    {
                        System.Console.WriteLine(songList.ItemByPlayOrder[i].Name);
                        System.Console.ReadKey();
                        songList.ItemByPlayOrder[i].Play();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            System.Console.ReadKey();
        }
    }
}
